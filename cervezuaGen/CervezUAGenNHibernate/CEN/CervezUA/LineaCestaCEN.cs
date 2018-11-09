

using System;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.Exceptions;

using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;


namespace CervezUAGenNHibernate.CEN.CervezUA
{
/*
 *      Definition of the class LineaCestaCEN
 *
 */
public partial class LineaCestaCEN
{
private ILineaCestaCAD _ILineaCestaCAD;

public LineaCestaCEN()
{
        this._ILineaCestaCAD = new LineaCestaCAD ();
}

public LineaCestaCEN(ILineaCestaCAD _ILineaCestaCAD)
{
        this._ILineaCestaCAD = _ILineaCestaCAD;
}

public ILineaCestaCAD get_ILineaCestaCAD ()
{
        return this._ILineaCestaCAD;
}

public int New_ (int p_cesta, int p_numero)
{
        LineaCestaEN lineaCestaEN = null;
        int oid;

        //Initialized LineaCestaEN
        lineaCestaEN = new LineaCestaEN ();

        if (p_cesta != -1) {
                // El argumento p_cesta -> Property cesta es oid = false
                // Lista de oids id
                lineaCestaEN.Cesta = new CervezUAGenNHibernate.EN.CervezUA.CestaEN ();
                lineaCestaEN.Cesta.Id = p_cesta;
        }

        lineaCestaEN.Numero = p_numero;

        //Call to LineaCestaCAD

        oid = _ILineaCestaCAD.New_ (lineaCestaEN);
        return oid;
}

public void Modify (int p_LineaCesta_OID, int p_numero)
{
        LineaCestaEN lineaCestaEN = null;

        //Initialized LineaCestaEN
        lineaCestaEN = new LineaCestaEN ();
        lineaCestaEN.Id = p_LineaCesta_OID;
        lineaCestaEN.Numero = p_numero;
        //Call to LineaCestaCAD

        _ILineaCestaCAD.Modify (lineaCestaEN);
}

public void Destroy (int id
                     )
{
        _ILineaCestaCAD.Destroy (id);
}
}
}
