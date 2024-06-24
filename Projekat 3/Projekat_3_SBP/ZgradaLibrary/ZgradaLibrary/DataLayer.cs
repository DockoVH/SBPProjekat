﻿using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using ZgradaLibrary.Entiteti;
using ZgradaLibrary.Mapiranja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ZgradaLibrary;

class DataLayer
{
    private static ISessionFactory? _factory = null;
    private static object objLock = new object();

    public static ISession? GetSession()
    {
        if(_factory == null)
        {
            lock(objLock)
            {
                if(_factory == null)
                {
                    _factory ??= CreateSessionFactory();
                }
            }
        }

        return _factory?.OpenSession();
    }

    private static ISessionFactory? CreateSessionFactory()
    {
        try
        {
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S18799;Password=dockofaks"));

            return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                    .BuildSessionFactory();
        }
        catch(Exception ex)
        {
            ex.HandleError();
            return null;
        }
    }
}
