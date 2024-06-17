using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManipulations.Entities
{
    public class ProductCategory
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
    }

    public sealed class  ProductCategoryMap : ClassMap<ProductCategory>
    {
        public ProductCategoryMap()
            {
            Table("PRODUCT_CATEGORIES");
            Id(x =>x.Id).GeneratedBy.Identity();
            Map(x => x.Name);
            }

    }
}
