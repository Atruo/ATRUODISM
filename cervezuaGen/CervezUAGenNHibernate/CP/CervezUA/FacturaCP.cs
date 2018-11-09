
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using CervezUAGenNHibernate.Exceptions;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;



namespace CervezUAGenNHibernate.CP.CervezUA
{
public partial class FacturaCP : BasicCP
{
public FacturaCP() : base ()
{
}

public FacturaCP(ISession sessionAux)
        : base (sessionAux)
{
}
}
}
