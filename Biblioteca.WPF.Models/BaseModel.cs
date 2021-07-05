using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.WPF.Models
{
    public abstract class BaseModel : BindableBase
    {
        private Guid id;
        public Guid Id 
        {
            get
            {
                return id;
            } 
            set
            {
                if (id != value)
                {
                    id = value;
                    RaisePropertyChanged();
                }
            }
        }
    }

}
