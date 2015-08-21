using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Linq.Expressions; 
using System.Reflection;
using System.Collections;
using System.Web.OData.Query;

namespace Core.Common.Core
{
    public class TempObjectBase : INotifyPropertyChanged
    {
        private event PropertyChangedEventHandler _PropertyChanged;
        List<PropertyChangedEventHandler> _PropertyChangeEventSubscribers = new List<PropertyChangedEventHandler>();
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                if (!_PropertyChangeEventSubscribers.Contains(value))
                {
                    _PropertyChanged += value;
                    _PropertyChangeEventSubscribers.Add(value);
                }
            }
            remove
            {
                _PropertyChanged -= value;
                _PropertyChangeEventSubscribers.Remove(value);
            }
        }

        protected virtual void OnPropertyChanged ( string propertyName )
        {
            OnPropertyChanged(propertyName, true);
        }

        protected virtual void OnPropertyChanged ( string propertyName, bool makeDirty )
        {
            if (_PropertyChanged != null)
            {
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            if (makeDirty)
            {
                _IsDirty = true;
            }
        }

        protected virtual void OnPropertyChanged<T> ( Expression<Func<T>> propertyExpression )
        {
            string propertyName = Microsoft.Practices.Prism.Mvvm.PropertySupport.ExtractPropertyName(propertyExpression);
            OnPropertyChanged(propertyName);
        }
        private bool _IsDirty;

        [NotNavigable]
        public bool IsDirty
        {
            get { return _IsDirty; }
            set { _IsDirty = value; }
        }

        protected List<TempObjectBase> GetDirtyObjects ()
        {
            List<TempObjectBase> dirtyObjects = new List<TempObjectBase>();

            List<TempObjectBase> visited = new List<TempObjectBase>();
            Action<TempObjectBase> walk = null;

            walk = ( o ) =>
            {
                if (o != null && !visited.Contains(o))
                {

                    visited.Add(o);

                    if (o.IsDirty) { dirtyObjects.Add(o); }

                    bool exitWalk = false;

                    if (!exitWalk)
                    {
                        PropertyInfo[] properties = o.GetBrowsableProperties();
                        foreach (PropertyInfo property in properties)
                        {
                            if (property.PropertyType.IsSubclassOf(typeof(TempObjectBase)))
                            {
                                TempObjectBase obj = (TempObjectBase)(property.GetValue(o, null));
                                walk(obj);
                            }
                            else
                            {
                                IList coll = property.GetValue(o, null) as IList;
                                if (coll != null)
                                {
                                    //don't do anything with the "coll" specifically

                                    foreach (object item in coll)
                                    {
                                        if (item is TempObjectBase)
                                        {
                                            walk((TempObjectBase)item);
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                walk(this);

                return dirtyObjects;
            };
        }

        private PropertyInfo[] GetBrowsableProperties ()
        {
            throw new NotImplementedException();
        }
    }
}