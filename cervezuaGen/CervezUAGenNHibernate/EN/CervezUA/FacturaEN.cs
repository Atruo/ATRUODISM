
using System;
// Definición clase FacturaEN
namespace CervezUAGenNHibernate.EN.CervezUA
{
public partial class FacturaEN
{
/**
 *	Atributo pedido
 */
private CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido;



/**
 *	Atributo id
 */
private int id;



/**
 *	Atributo importe
 */
private double importe;



/**
 *	Atributo direccion
 */
private string direccion;



/**
 *	Atributo metodoPago
 */
private CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum metodoPago;






public virtual CervezUAGenNHibernate.EN.CervezUA.PedidoEN Pedido {
        get { return pedido; } set { pedido = value;  }
}



public virtual int Id {
        get { return id; } set { id = value;  }
}



public virtual double Importe {
        get { return importe; } set { importe = value;  }
}



public virtual string Direccion {
        get { return direccion; } set { direccion = value;  }
}



public virtual CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum MetodoPago {
        get { return metodoPago; } set { metodoPago = value;  }
}





public FacturaEN()
{
}



public FacturaEN(int id, CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido, double importe, string direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum metodoPago
                 )
{
        this.init (Id, pedido, importe, direccion, metodoPago);
}


public FacturaEN(FacturaEN factura)
{
        this.init (Id, factura.Pedido, factura.Importe, factura.Direccion, factura.MetodoPago);
}

private void init (int id
                   , CervezUAGenNHibernate.EN.CervezUA.PedidoEN pedido, double importe, string direccion, CervezUAGenNHibernate.Enumerated.CervezUA.MetodoPagoEnum metodoPago)
{
        this.Id = id;


        this.Pedido = pedido;

        this.Importe = importe;

        this.Direccion = direccion;

        this.MetodoPago = metodoPago;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        FacturaEN t = obj as FacturaEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
