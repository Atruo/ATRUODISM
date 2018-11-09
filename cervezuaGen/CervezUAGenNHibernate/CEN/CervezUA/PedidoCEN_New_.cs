
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using CervezUAGenNHibernate.Exceptions;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;


/*PROTECTED REGION ID(usingCervezUAGenNHibernate.CEN.CervezUA_Pedido_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace CervezUAGenNHibernate.CEN.CervezUA
{
public partial class PedidoCEN
{
public int New_ (string p_usuario)
{
        /*PROTECTED REGION ID(CervezUAGenNHibernate.CEN.CervezUA_Pedido_new__customized) START*/

        PedidoEN pedidoEN = null;

        int oid;

        //Initialized PedidoEN
        pedidoEN = new PedidoEN ();

        if (p_usuario != null) {
                pedidoEN.Usuario = new CervezUAGenNHibernate.EN.CervezUA.UsuarioEN ();
                pedidoEN.Usuario.NUsuario = p_usuario;
        }

        //Call to PedidoCAD

        oid = _IPedidoCAD.New_ (pedidoEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
