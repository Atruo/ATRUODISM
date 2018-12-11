
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CervezUAGenNHibernate.EN.CervezUA;
using CervezUAGenNHibernate.CEN.CervezUA;
using CervezUAGenNHibernate.CAD.CervezUA;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
        /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/
        try
        {
                // Insert the initilizations of entities using the CEN classes


                UsuarioCEN customer = new UsuarioCEN ();
                PedidoCEN pedido = new PedidoCEN ();
                LineaPedidoCEN lineaPedido = new LineaPedidoCEN ();

                ValoracionCEN valoracion = new ValoracionCEN ();
                ArticuloCEN articulo = new ArticuloCEN ();
                
                
               // ArticuloEN articuloNuevo = new ArticuloEN ();


                customer.New_ (p_nUsuario: "Mau", p_email: "mau@mau.mau", p_fecNam: DateTime.Parse ("2018-01-01"), p_nombre: "Mau", p_apellidos: "Morant", p_foto: "mau.png", p_tipo: (CervezUAGenNHibernate.Enumerated.CervezUA.TipoUsuarioEnum) 1, p_pass: "mau123");
                pedido.New_ (p_usuario:"Mau");
                //lineaPedido.New_ (p_pedido: 1, p_articulo: articuloNuevo, p_numero: 2);
                //valoracion.New_ (p_articulo: 1, p_usuario: "Mau", p_valoracion: 3, p_texto: "Maravilloso licor de fresa");
               // articulo.New_(p_nombre: "Agua Fresca", p_stock: 13, p_precio: 13, p_valMedia: 2, p_descripcion: "Agua del grifo", p_imagen: "agua.png", p_marca: "Fontbella");




                /*PROTECTED REGION END*/
            }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
