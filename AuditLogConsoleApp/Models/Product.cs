using System;
using System.Collections.Generic;
using System.Text;
using AuditLogTracking;

namespace AuditLogConsoleApp.Models
{
    public class Product : AuditLogBase
    {
        public Product(string userContextName) : base(nameof(Product), userContextName)
        {
            base.Initialize();
        }

        private string _productNumber;

        public string ProductNumber
        {
            get => _productNumber;
            set
            {
                _productNumber = value;
                base.OnChanges();
            }
        }

        private decimal _productCost;
        public decimal ProductCost
        {
            get => _productCost;
            set
            {
                _productCost = value;
                base.OnChanges();
            }
        }

        private string _sku;
        public string Sku
        {
            get => _sku;
            set
            {
                _sku = value;
                base.OnChanges();
            }
        }

        private double _length;
        public double Length
        {
            get => _length;
            set
            {
                _length = value;
                base.OnChanges();
            }
        }

        private double _width;
        public double Width
        {
            get => _width;
            set
            {
                _width = value;
                base.OnChanges();
            }
        }

        private double _height;
        public double Height
        {
            get => _height;
            set
            {
                _height = value;
                base.OnChanges();
            }
        }

        private double _weight;
        public double Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                base.OnChanges();
            }
        }
    }
}
