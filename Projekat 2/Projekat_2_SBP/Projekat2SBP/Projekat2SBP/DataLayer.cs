using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using Projekat2SBP.Entiteti;
using Projekat2SBP.Mapiranja;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekat2SBP;

class DataLayer
{
    private static ISessionFactory _factory = null;
    private static object objLock = new object();

    public static ISession? GetSession()
    {
        if(_factory == null)
        {
            lock(objLock)
            {
                if(_factory == null)
                {
                    _factory = CreateSessionFactory();
                }
            }
        }

        return _factory.OpenSession();
    }

    private static ISessionFactory CreateSessionFactory()
    {
        try
        {
            var cfg = OracleManagedDataClientConfiguration.Oracle10
                .ShowSql()
                .ConnectionString(c =>
                    c.Is("Data Source=gislab-oracle.elfak.ni.ac.rs:1521/SBP_PDB;User Id=S18799;Password=dockofaks"));

            return Fluently.Configure()
                    .Database(cfg)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<ZgradaMapiranja>())
                    .BuildSessionFactory();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.FormatExceptionMessage());
            using (StreamWriter sw = new StreamWriter("C:\\Users\\Docko\\Desktop\\Greska.txt"))
            {
                sw.WriteLine(ex.FormatExceptionMessage());
            }
            return null;
        }
    }
}
