using DBManipulations.Entities;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManipulations
{
    
        public class NHibernateHelper
        {
            private static ISessionFactory? _sessionFactory;

            private static ISessionFactory SessionFactory
            {
                get
                {
                    if (_sessionFactory == null)
                    {
                        _sessionFactory = Fluently.Configure()
                            .Database(MySQLConfiguration.Standard
                                .ConnectionString(@"Server=localhost;Database=test1;User Id=root;Password=root123;")
                             )
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
                            .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProductCategoryMap>())
                            .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                            .BuildSessionFactory();
                    }
                    return _sessionFactory;
                }
            }

            public static ISession OpenSession()
            {
                return SessionFactory.OpenSession();
            }
        }
    }

