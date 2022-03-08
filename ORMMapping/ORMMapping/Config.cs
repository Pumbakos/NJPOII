using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace ORMMapping
{
    public class Config
    {
        private static void BuildSchema(Configuration config)
        {
            // this NHibernate tool takes a configuration (with mapping info in)
            // and exports a database schema from it
            new SchemaExport(config)
                .Create(false, true);
        }

        public static ISessionFactory CreateSessionFactory(params Type[] mappingTypes)
        {
            return Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile("database.sqlite"))
                .Mappings(m =>
                {
                    foreach (var mappingType in mappingTypes)
                        m.FluentMappings.Add(mappingType);
                })
                .ExposeConfiguration(BuildSchema) //Call of ours BuildSchema
                .BuildSessionFactory();
        }
    }
}