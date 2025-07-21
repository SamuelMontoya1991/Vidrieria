using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Vidrieria.Formularios.Factura;
using Vidrieria.Modelos;

namespace Vidrieria.Clases
{
    public class ConexionDB
    {
        private string servidor = "DESKTOP-J7CCPL4";
        private string baseDatos = "Vidrieria";
        private string usuario = "samuel";
        private string password = "Master2025.";
        private readonly string connectionString;

        public ConexionDB()
        {
            connectionString = $"Server={servidor};Database={baseDatos};User Id={usuario};Password={password};TrustServerCertificate=True;";
        }
        //metodo inicio sesion
        public bool ValidarLogin(string usuario, string clave)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = "SELECT clave FROM Sis_Usuarios WHERE Usuario = @Usuario";
                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    try
                    {
                        conexion.Open();
                        object resultado = comando.ExecuteScalar();
                        if (resultado != null)
                        {
                            string claveAlmacenada = resultado.ToString();
                            return VerificarClave(clave, claveAlmacenada);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al validar login: " + ex.Message);
                    }
                }
            }
            return false;
        }
        //metodos de cliente
        public bool InsertarCliente(Cliente cliente)
        {
            bool insertado = false;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO sis_clientes 
                        (id_cliente, nombrecliente, identidad, RTN, direccion, telefono, correo) 
                        VALUES 
                        (@IdCliente, @NombreCliente, @Identidad, @RTN, @Direccion, @Telefono, @Correo)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    comando.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                    comando.Parameters.AddWithValue("@Identidad", cliente.Identidad);
                    comando.Parameters.AddWithValue("@RTN", cliente.Rtn);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        insertado = filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar cliente con ID: " + ex.Message);
                    }
                }
            }

            return insertado;
        }
        public bool ActualizarCliente(Cliente cliente)
        {
            bool actualizado = false;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"UPDATE sis_clientes 
                         SET nombrecliente = @NombreCliente,
                             identidad = @Identidad,
                             RTN = @RTN,
                             direccion = @Direccion,
                             telefono = @Telefono,
                             correo = @Correo
                         WHERE id_cliente = @IdCliente";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdCliente", cliente.IdCliente);
                    comando.Parameters.AddWithValue("@NombreCliente", cliente.NombreCliente);
                    comando.Parameters.AddWithValue("@Identidad", cliente.Identidad);
                    comando.Parameters.AddWithValue("@RTN", cliente.Rtn);
                    comando.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                    comando.Parameters.AddWithValue("@Correo", cliente.Correo);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        actualizado = filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar cliente: " + ex.Message);
                    }
                }
            }

            return actualizado;
        }
        public Usuario? ObtenerUsuarioSiValido(bool validado, string nombreUsuario)
        {
            if (!validado)
                return null;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Id_Usuario, Nombre, Usuario, Clave, Estado, Nivel
            FROM sis_Usuarios
            WHERE Usuario = @nombreUsuario";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@nombreUsuario", nombreUsuario);

                    conexion.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario
                            {
                                Id_Usuario = reader.GetInt32(0),
                                Nombre = reader.IsDBNull(1) ? null : reader.GetString(1),
                                nombreUsuario = reader.IsDBNull(2) ? null : reader.GetString(2),
                                Clave = reader.IsDBNull(3) ? null : reader.GetString(3),
                                Estado = reader.IsDBNull(4) ? null : reader.GetInt32(4),
                                Nivel = reader.IsDBNull(5) ? null : reader.GetInt32(5)
                            };
                        }
                    }
                }
            }

            return null;
        }

        //metodos de empresa
        public bool InsertarEmpresa(ModeloEmpresa empresa)
        {
            bool insertado = false;
            string query = @"INSERT INTO sis_empresa 
                            (id_empresa, nombre, direccion, telefono, correo, RTN, encabezado, encabezado2, eslogan, nota)
                            VALUES 
                            (@id_empresa, @nombre, @direccion, @telefono, @correo, @RTN, @encabezado, @encabezado2, @eslogan, @nota)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id_empresa", empresa.id_empresa ?? "");
                comando.Parameters.AddWithValue("@nombre", empresa.nombre ?? "");
                comando.Parameters.AddWithValue("@direccion", empresa.direccion ?? "");
                comando.Parameters.AddWithValue("@telefono", empresa.telefono ?? "");
                comando.Parameters.AddWithValue("@correo", empresa.correo ?? "");
                comando.Parameters.AddWithValue("@RTN", empresa.RTN ?? "");
                comando.Parameters.AddWithValue("@encabezado", empresa.encabezado ?? "");
                comando.Parameters.AddWithValue("@encabezado2", empresa.encabezado2 ?? "");
                comando.Parameters.AddWithValue("@eslogan", empresa.eslogan ?? "");
                comando.Parameters.AddWithValue("@nota", empresa.nota ?? "");

                try
                {
                    conexion.Open();
                    insertado = comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar empresa: " + ex.Message);
                }
            }

            return insertado;
        }
        public bool ActualizarEmpresa(ModeloEmpresa empresa)
        {
            bool actualizado = false;
            string query = @"UPDATE sis_empresa SET 
                            nombre = @nombre,
                            direccion = @direccion,
                            telefono = @telefono,
                            correo = @correo,
                            RTN = @RTN,
                            encabezado = @encabezado,
                            encabezado2 = @encabezado2,
                            eslogan = @eslogan,
                            nota = @nota
                            WHERE id_empresa = @id_empresa";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id_empresa", empresa.id_empresa ?? "");
                comando.Parameters.AddWithValue("@nombre", empresa.nombre ?? "");
                comando.Parameters.AddWithValue("@direccion", empresa.direccion ?? "");
                comando.Parameters.AddWithValue("@telefono", empresa.telefono ?? "");
                comando.Parameters.AddWithValue("@correo", empresa.correo ?? "");
                comando.Parameters.AddWithValue("@RTN", empresa.RTN ?? "");
                comando.Parameters.AddWithValue("@encabezado", empresa.encabezado ?? "");
                comando.Parameters.AddWithValue("@encabezado2", empresa.encabezado2 ?? "");
                comando.Parameters.AddWithValue("@eslogan", empresa.eslogan ?? "");
                comando.Parameters.AddWithValue("@nota", empresa.nota ?? "");

                try
                {
                    conexion.Open();
                    actualizado = comando.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar empresa: " + ex.Message);
                }
            }

            return actualizado;
        }
        public ModeloEmpresa? ObtenerEmpresa()
        {
            ModeloEmpresa? empresa = null;

            string query = @"SELECT TOP 1 id_empresa, nombre, direccion, telefono, correo, RTN, 
                            encabezado, encabezado2, eslogan, nota 
                     FROM sis_empresa";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            empresa = new ModeloEmpresa
                            {
                                id_empresa = lector["id_empresa"].ToString(),
                                nombre = lector["nombre"].ToString(),
                                direccion = lector["direccion"].ToString(),
                                telefono = lector["telefono"].ToString(),
                                correo = lector["correo"].ToString(),
                                RTN = lector["RTN"].ToString(),
                                encabezado = lector["encabezado"].ToString(),
                                encabezado2 = lector["encabezado2"].ToString(),
                                eslogan = lector["eslogan"].ToString(),
                                nota = lector["nota"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener empresa: " + ex.Message);
                }
            }

            return empresa;
        }
        //metodos de cai
        public bool InsertarCai(ModeloCai cai)
        {
            bool insertado = false;
            string query = @"INSERT INTO sis_cai (cai, rango_inicial, rango_final, fecha_limite, estado) 
                     VALUES (@cai, @rango_inicial, @rango_final, @fecha_limite, @estado)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@cai", cai.cai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rango_inicial", cai.rango_inicial ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rango_final", cai.rango_final ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_limite", cai.fecha_limite ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", cai.estado ?? (object)DBNull.Value);

                try
                {
                    conexion.Open();
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar CAI: " + ex.Message);
                }
            }

            return insertado;
        }
        public bool ActualizarCai(ModeloCai cai)
        {
            bool actualizado = false;

            string query = @"UPDATE sis_cai SET
                        cai = @cai,
                        rango_inicial = @rango_inicial,
                        rango_final = @rango_final,
                        fecha_limite = @fecha_limite,
                        estado = @estado
                     WHERE id_cai = @idcai";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@cai", cai.cai ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rango_inicial", cai.rango_inicial ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@rango_final", cai.rango_final ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fecha_limite", cai.fecha_limite ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", cai.estado ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@idcai", cai.id_cai ?? (object)DBNull.Value);

                try
                {
                    conexion.Open();
                    actualizado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al actualizar CAI: " + ex.Message);
                }
            }

            return actualizado;
        }
        //metodos de gastos
        public bool InsertarGasto(TipoGasto gasto)
        {
            bool insertado = false;
            string query = @"INSERT INTO Sis_gastos 
        (id_gasto, tipo_gasto, cantidad, observacion, nodocumento, fechacompra, id_usuario) 
        VALUES 
        (@id_gasto, @tipo_gasto, @cantidad, @observacion, @nodocumento, @fechacompra, @id_usuario)";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                cmd.Parameters.AddWithValue("@id_gasto", gasto.id ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@tipo_gasto", gasto.tipoGasto ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@cantidad", gasto.cantidad ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@observacion", gasto.observacion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nodocumento", gasto.documento ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@fechacompra", gasto.fechaCompra ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id_usuario", gasto.idUsuario.ToString() ?? (object)DBNull.Value);

                try
                {
                    conexion.Open();
                    insertado = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al insertar gasto: " + ex.Message);
                }
            }

            return insertado;
        }
        public DataTable ObtenerTodosGastos()
        {
            DataTable tabla = new DataTable();
            string query = "SELECT * FROM Sis_gastos";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(query, conexion);
                    adaptador.Fill(tabla);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener gastos: " + ex.Message);
                }
            }

            return tabla;
        }
        //metodo de material
        public bool ActualizarMaterial(ModeloMaterial material, string tabla, string tipo)
        {
            bool actualizado = false;
            string query = $@"UPDATE {tabla} SET
                        descripcion = @descripcion,
                        costonatural = @natural,
                        costobronce = @bronce,
                        costomadera = @madera,
                        arcos = @arco,
                        vlivianacorr = @livianacorrediza,
                        vsemipesada = @semipesada,
                        vfijapesada = @fijapesada,
                        vfijaliviana = @fijaliviana,
                        guillotina = @guillotina,
                        pvpesada = @pvpesada,
                        pvpesadadoble = @pvpesadadoble,
                        pabatible = @pabatible,
                        pbaniousa = @pbaniousa,
                        pbanio = @pbanio,
                        vitrina = @vitrina,
                        extras = @extras,
                        tipo_presentacion = @tipo
                    WHERE {tipo} = @id";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", material.id);
                comando.Parameters.AddWithValue("@descripcion", material.descripcion ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@natural", material.natural);
                comando.Parameters.AddWithValue("@bronce", material.bronce);
                comando.Parameters.AddWithValue("@madera", material.madera);
                comando.Parameters.AddWithValue("@arco", material.arco);
                comando.Parameters.AddWithValue("@livianacorrediza", material.livianacorrediza);
                comando.Parameters.AddWithValue("@semipesada", material.semipesada);
                comando.Parameters.AddWithValue("@fijapesada", material.fijapesada);
                comando.Parameters.AddWithValue("@fijaliviana", material.fijaliviana);
                comando.Parameters.AddWithValue("@guillotina", material.guillotina);
                comando.Parameters.AddWithValue("@pvpesada", material.pvpesada);
                comando.Parameters.AddWithValue("@pvpesadadoble", material.pvpesadadoble);
                comando.Parameters.AddWithValue("@pabatible", material.pabatible);
                comando.Parameters.AddWithValue("@pbaniousa", material.pbaniousa);
                comando.Parameters.AddWithValue("@pbanio", material.pbanio);
                comando.Parameters.AddWithValue("@vitrina", material.vitrina);
                comando.Parameters.AddWithValue("@extras", material.extra);
                comando.Parameters.AddWithValue("@tipo", material.tipo);

                try
                {
                    conexion.Open();
                    int filas = comando.ExecuteNonQuery();
                    actualizado = filas > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar material: " + ex.Message);
                }
            }

            return actualizado;
        }
        //metodos usuarios
        public bool InsertarUsuario(Usuario usuario)
        {
            bool insertado = false;
            string claveEncriptada = EncriptarCadena(usuario.Clave!);

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Sis_Usuarios 
                        (id_usuario,Nombre, Usuario, clave, estado, nivel) 
                         VALUES 
                        (@id,@Nombre, @Usuario, @clave, @estado, @nivel)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@id", usuario.Id_Usuario);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    comando.Parameters.AddWithValue("@clave", claveEncriptada);
                    comando.Parameters.AddWithValue("@estado", (object)usuario.Estado! ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@nivel", (object)usuario.Nivel! ?? DBNull.Value);


                    try
                    {
                        conexion.Open();
                        insertado = comando.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar usuario: " + ex.Message);
                    }
                }
            }
            return insertado;
        }
        public bool ActualizarUsuario(Usuario usuario)
        {
            bool actualizado = false;
            string claveEncriptada = EncriptarCadena(usuario.Clave!);

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"UPDATE Sis_Usuarios SET
                         Nombre = @Nombre,
                         Usuario = @Usuario,
                         clave = @clave,
                         estado = @estado,
                         nivel = @nivel
                         WHERE Id_Usuario = @Id_Usuario";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@Id_Usuario", usuario.Id_Usuario);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Usuario", usuario.nombreUsuario);
                    comando.Parameters.AddWithValue("@clave", claveEncriptada);
                    comando.Parameters.AddWithValue("@estado", (object)usuario.Estado! ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@nivel", (object)usuario.Nivel! ?? DBNull.Value);


                    try
                    {
                        conexion.Open();
                        actualizado = comando.ExecuteNonQuery() > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar usuario: " + ex.Message);
                    }
                }
            }
            return actualizado;
        }
        //metodos cotizaciones
        public bool InsertarCotizacionCompleta(CotizacionCompleta cotizacionCompleta, int usuario)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    // Insertar Cotizacion
                    string queryCotizacion = @"
                INSERT INTO Sis_Cotizaciones (id_cotizacion, cliente_id, usuario_id, empresa_id, id_vendedor, observaciones, factura)
                VALUES (@id_cotizacion, @cliente_id, @usuario_id, @empresa_id, @id_vendedor, @observaciones, @factura)";

                    using (SqlCommand cmd = new SqlCommand(queryCotizacion, conexion, transaccion))
                    {
                        cmd.Parameters.AddWithValue("@id_cotizacion", cotizacionCompleta.Cotizacion.IdCotizacion);
                        cmd.Parameters.AddWithValue("@cliente_id", cotizacionCompleta.Cotizacion.ClienteId);
                        cmd.Parameters.AddWithValue("@usuario_id", cotizacionCompleta.Cotizacion.UsuarioId);
                        cmd.Parameters.AddWithValue("@empresa_id", cotizacionCompleta.Cotizacion.EmpresaId);
                        cmd.Parameters.AddWithValue("@id_vendedor", cotizacionCompleta.Cotizacion.IdVendedor);
                        cmd.Parameters.AddWithValue("@observaciones", (object?)cotizacionCompleta.Cotizacion.Observaciones ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@factura", (object?)cotizacionCompleta.Cotizacion.Factura ?? DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }

                    // Insertar Detalles
                    foreach (var detalle in cotizacionCompleta.Detalles)
                    {
                        string queryDetalle = @"
                    INSERT INTO sis_Cotizaciones_Detalle (id_cotizacion, id_trabajo, medidas, area, cantidad, precio, costo, color)
                    VALUES (@id_cotizacion, @id_trabajo, @medidas, @area, @cantidad, @precio, @costo, @color)";

                        using (SqlCommand cmd = new SqlCommand(queryDetalle, conexion, transaccion))
                        {
                            cmd.Parameters.AddWithValue("@id_cotizacion", detalle.IdCotizacion);
                            cmd.Parameters.AddWithValue("@id_trabajo", detalle.IdTrabajo);
                            cmd.Parameters.AddWithValue("@medidas", detalle.Medidas);
                            cmd.Parameters.AddWithValue("@area", detalle.Area);
                            cmd.Parameters.AddWithValue("@cantidad", detalle.Cantidad);
                            cmd.Parameters.AddWithValue("@precio", detalle.Precio);
                            cmd.Parameters.AddWithValue("@costo", detalle.Costo);
                            cmd.Parameters.AddWithValue("@color", detalle.Color);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    if (cotizacionCompleta.MaterialesUsados.Count == 0) { } else {
                        // Insertar MaterialesUsados
                        foreach (var material in cotizacionCompleta.MaterialesUsados)
                        {
                            string queryMaterial = @"
                                INSERT INTO Sis_Materiales_Usados (id_cotizacion, descripcion, usado, id_trabajo)
                                VALUES (@id_cotizacion, @descripcion, @utilizado, @id_trabajo)";

                            using (SqlCommand cmd = new SqlCommand(queryMaterial, conexion, transaccion))
                            {
                                cmd.Parameters.AddWithValue("@id_cotizacion", material.IdCotizacion);
                                cmd.Parameters.AddWithValue("@descripcion", material.Descripcion);
                                cmd.Parameters.AddWithValue("@utilizado", material.Utilizado);
                                cmd.Parameters.AddWithValue("@id_trabajo", material.id_trabajo);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                        

                    transaccion.Commit();
                    return true;
                }
                catch
                {
                    transaccion.Rollback();
                    return false;
                }
            }
        }
        public Cotizacion obtenerCotizacion(int idCotizacion)
        {
            Cotizacion? cotizacion = null;
            string query = @"SELECT id_cotizacion, cliente_id, usuario_id, empresa_id, id_vendedor, observaciones,factura,fecha FROM vwCotizaciones WHERE id_cotizacion = @id_cotizacion";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id_cotizacion", idCotizacion);
                try
                {
                    conexion.Open();
                    using (SqlDataReader lector = comando.ExecuteReader())
                    {
                        if (lector.Read())
                        {
                            cotizacion = new Cotizacion(
                                lector.GetInt32(0),
                                lector.GetInt32(1),
                                lector.GetInt32(2),
                                lector.GetInt32(3),
                                lector.GetInt32(4),
                                lector.IsDBNull(5) ? null : lector.GetString(5),
                                lector.IsDBNull(6) ? null : lector.GetInt32(6),
                                lector.IsDBNull(7) ? null : lector.GetDateTime(7)
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener cotización: " + ex.Message);
                }
            }
            return cotizacion!;
        }
        public List<DetalleCotizacion> obtenerCotizacionDetalle(int idCotizacion)
        {
            var detalles = new List<DetalleCotizacion>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id_Cotizacion, Id_Trabajo, Medidas, Area, Cantidad, Precio, Costo, Color, descripcion
                         FROM vwCotizaciones 
                         WHERE Id_Cotizacion = @IdCotizacion";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int idTrabajo = reader.GetInt32(1);
                        string medidas = reader.GetString(2);
                        decimal area = reader.GetDecimal(3);
                        int cantidad = reader.GetInt32(4);
                        decimal precio = reader.GetDecimal(5);
                        decimal costo = reader.GetDecimal(6);
                        string color = reader.IsDBNull(7) ? "Natural" : reader.GetString(7);
                        string descripcion = reader.GetString(8);

                        var detalle = new DetalleCotizacion(
                            idCotizacion, idTrabajo, medidas, area, cantidad, precio, costo, color, descripcion
                        );

                        detalles.Add(detalle);
                    }
                }
            }

            return detalles;
        }
        public List<MaterialesUsados> obtenerMaterialesUsados(int idCotizacion)
        {
            var materiales = new List<MaterialesUsados>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"SELECT Id_Cotizacion, Descripcion, usado, id_trabajo, nombretrabajo
                         FROM vwMaterialesUsados 
                         WHERE Id_Cotizacion = @IdCotizacion";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdCotizacion", idCotizacion);

                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var material = new MaterialesUsados
                        {
                            IdCotizacion = reader.GetInt32(0),
                            Descripcion = reader.GetString(1),
                            Utilizado = reader.GetDecimal(2),
                            id_trabajo = reader.GetInt32(3),
                            NombreTrabajo = reader.GetString(4),
                        };

                        materiales.Add(material);
                    }
                }
            }

            return materiales;
        }
        public CotizacionCompleta obtenerCotizacionCompleta(int idCotizacion)
        {
            CotizacionCompleta? cotizacionCompleta = new CotizacionCompleta(
                obtenerCotizacion(idCotizacion),
                obtenerCotizacionDetalle(idCotizacion),
                obtenerMaterialesUsados(idCotizacion)
                );
            return cotizacionCompleta!;
        }
        //metodos de factura
        public bool InsertarFacturaCompleta(FacturaCompleta facturaCompleta)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                conexion.Open();
                SqlTransaction transaccion = conexion.BeginTransaction();

                try
                {
                    
                    string queryFactura = @"
                INSERT INTO sis_Factura 
                (id_factura, id_cliente, id_usuario, id_empresa, id_vendedor, id_cai, rtn, tipo_factura, id_cotizacion,pagado)
                VALUES 
                (@idFactura, @ClienteId, @UsuarioId, @EmpresaId, @VendedorId, @idCai, @RTN, @TipoFactura, @IdCotizacion, @pagado);";

                    SqlCommand cmdFactura = new SqlCommand(queryFactura, conexion, transaccion);
                    cmdFactura.Parameters.AddWithValue("@idFactura", facturaCompleta.Factura.IDFactura);
                    cmdFactura.Parameters.AddWithValue("@ClienteId", facturaCompleta.Factura.ClienteId);
                    cmdFactura.Parameters.AddWithValue("@UsuarioId", facturaCompleta.Factura.UsuarioId);
                    cmdFactura.Parameters.AddWithValue("@EmpresaId", facturaCompleta.Factura.EmpresaId);
                    cmdFactura.Parameters.AddWithValue("@VendedorId", facturaCompleta.Factura.VendedorId);
                    cmdFactura.Parameters.AddWithValue("@idCai", facturaCompleta.Factura.IdCai);
                    cmdFactura.Parameters.AddWithValue("@RTN", facturaCompleta.Factura.RTN);
                    cmdFactura.Parameters.AddWithValue("@TipoFactura", facturaCompleta.Factura.TipoPago);
                    cmdFactura.Parameters.AddWithValue("@IdCotizacion", facturaCompleta.Factura.IdCotizacion);
                    cmdFactura.Parameters.AddWithValue("@pagado", facturaCompleta.Factura.Pagado ?? 0);
                    cmdFactura.ExecuteNonQuery();

                    
                    string queryDetalle = @"
                INSERT INTO sis_Factura_Detalle 
                (id_factura, Id_Trabajo, Medidas, Area, Cantidad, Precio, Costo, Color)
                VALUES 
                (@IDFactura, @IdTrabajo, @Medidas, @Area, @Cantidad, @Precio, @Costo, @Color);";

                    foreach (var detalle in facturaCompleta.Detalles)
                    {
                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conexion, transaccion);
                        cmdDetalle.Parameters.AddWithValue("@IDFactura", facturaCompleta.Factura.IDFactura);
                        cmdDetalle.Parameters.AddWithValue("@IdTrabajo", detalle.IdTrabajo);
                        cmdDetalle.Parameters.AddWithValue("@Medidas", detalle.Medidas ?? "");
                        cmdDetalle.Parameters.AddWithValue("@Area", detalle.Area);
                        cmdDetalle.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@Precio", detalle.Precio);
                        cmdDetalle.Parameters.AddWithValue("@Costo", detalle.Costo);
                        cmdDetalle.Parameters.AddWithValue("@Color", detalle.Color ?? "Natural");
                        cmdDetalle.ExecuteNonQuery();
                    }

                    
                    string queryPago = @"
                INSERT INTO Sis_Forma_Pago 
                (id_Factura, Tipo_Pago, Subtotal, ISV, Cambio)
                VALUES 
                (@FacturaID, @TipoPago, @Subtotal, @ISV, @Cambio);";

                    SqlCommand cmdPago = new SqlCommand(queryPago, conexion, transaccion);
                    cmdPago.Parameters.AddWithValue("@FacturaID", facturaCompleta.Factura.IDFactura);
                    cmdPago.Parameters.AddWithValue("@TipoPago", facturaCompleta.formaPago.TipoPago);
                    cmdPago.Parameters.AddWithValue("@Subtotal", facturaCompleta.formaPago.Subtotal);
                    cmdPago.Parameters.AddWithValue("@ISV", facturaCompleta.formaPago.ISV);
                    cmdPago.Parameters.AddWithValue("@Cambio", facturaCompleta.formaPago.cambio);
                    cmdPago.ExecuteNonQuery();

                    transaccion.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    transaccion.Rollback();
                   
                    Console.WriteLine("Error al insertar FacturaCompleta: " + ex.Message);
                    return false;
                }
            }
        }
        public NuevaFactura ObtenerFactura(int idFactura)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_factura, id_cliente, id_usuario, id_empresa, id_vendedor, id_cai, rtn, tipo_factura, id_cotizacion, estado, pagado 
                         FROM sis_Factura
                         WHERE id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    conexion.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NuevaFactura
                            {
                                IDFactura = reader.GetInt32(0),
                                ClienteId = reader.GetInt32(1),
                                UsuarioId = reader.GetInt32(2),
                                EmpresaId = reader.GetInt32(3),
                                VendedorId = reader.GetInt32(4),
                                IdCai = reader.GetInt32(5),
                                RTN = reader.GetInt32(6),
                                TipoPago = reader.GetInt32(7),
                                IdCotizacion = reader.GetInt32(8),
                                Estado = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                                Pagado = reader.IsDBNull(10) ? 0 : reader.GetInt32(10)
                            };
                        }
                    }
                }
            }
            return null;
        }
        public List<FacturaDetalle> ObtenerDetallesFactura(int idFactura)
        {
            var detalles = new List<FacturaDetalle>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_factura, Id_Trabajo, Medidas, Area, Cantidad, Precio, Costo, Color 
                         FROM sis_Factura_Detalle
                         WHERE id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    conexion.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            detalles.Add(new FacturaDetalle
                            {
                                IDFactura = reader.GetInt32(0),
                                IdTrabajo = reader.GetInt32(1),
                                Medidas = reader.GetString(2),
                                Area = reader.GetDecimal(3),
                                Cantidad = reader.GetInt32(4),
                                Precio = reader.GetDecimal(5),
                                Costo = reader.GetDecimal(6),
                                Color = reader.GetString(7)
                            });
                        }
                    }
                }
            }

            return detalles;
        }
        public FormaPago ObtenerFormaPagoFactura(int idFactura)
        {
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"SELECT id_factura, Tipo_Pago, Subtotal, ISV, Cambio 
                         FROM Sis_Forma_Pago
                         WHERE id_factura = @idFactura";

                using (SqlCommand cmd = new SqlCommand(query, conexion))
                {
                    cmd.Parameters.AddWithValue("@idFactura", idFactura);
                    conexion.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new FormaPago
                            {
                                IDFactura = reader.GetInt32(0),
                                TipoPago = reader.GetInt32(1),
                                Subtotal = reader.GetDecimal(2),
                                ISV = reader.GetDecimal(3),
                                cambio = reader.GetDecimal(4)
                            };
                        }
                    }
                }
            }
            return null;
        }
        public FacturaCompleta ObtenerFacturaCompleta(int idFactura)
        {
            var factura = ObtenerFactura(idFactura);
            if (factura == null) return null;

            var detalles = ObtenerDetallesFactura(idFactura);
            var formaPago = ObtenerFormaPagoFactura(idFactura);

            return new FacturaCompleta
            (   factura,
                detalles,
                formaPago
            );
        }
        public void ActualizarEstadoFacturas()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
            UPDATE sis_Factura
            SET estado = 0
            WHERE estado = 1 AND CAST(fecha AS DATE) <> CAST(GETDATE() AS DATE)
        ";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<FacturaVencida> ObtenerFacturasVencidas()
        {
            var facturasVencidas = new List<FacturaVencida>();
            using (var connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT id_factura, nombrecliente, sum(distinct(subtotal+isv)) as total,DATEDIFF(DAY, fecha, GETDATE())-30 as diasVencidos
            FROM vwFacturas
            WHERE tipo_factura = 1 and pagado = 0 
			group by id_factura,NombreCliente,fecha";

                using (var cmd = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            facturasVencidas.Add(new FacturaVencida
                            {
                                IDFactura = reader.GetInt32(0),
                                Cliente = reader.GetString(1),
                                Total = reader.GetDecimal(2),
                                diasVencidos = reader.GetInt32(3)
                            });
                        }
                    }
                }
            }
            return facturasVencidas;
        }
        //metodos proveedores
        public bool InsertarProveedor(NuevoProveedor proveedor)
        {
            bool insertado = false;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO sis_proveedores 
                        (id_proveedor, nombreproveedor, identidad, RTN, direccion, telefono, correo) 
                        VALUES 
                        (@IdProveedor, @NombreProveedor, @Identidad, @RTN, @Direccion, @Telefono, @Correo)";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                    comando.Parameters.AddWithValue("@NombreProveedor", proveedor.NombreProveedor);
                    comando.Parameters.AddWithValue("@Identidad", proveedor.Identidad);
                    comando.Parameters.AddWithValue("@RTN", proveedor.Rtn);
                    comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@Correo", proveedor.Correo);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        insertado = filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al insertar proveedor con ID: " + ex.Message);
                    }
                }
            }

            return insertado;
        }
        public bool ActualizarProveedor(NuevoProveedor proveedor)
        {
            bool actualizado = false;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"UPDATE sis_proveedores 
                         SET nombreProveedor = @NombreProveedor,
                             identidad = @Identidad,
                             RTN = @RTN,
                             direccion = @Direccion,
                             telefono = @Telefono,
                             correo = @Correo
                         WHERE id_proveedor = @IdProveedor";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    comando.Parameters.AddWithValue("@IdProveedor", proveedor.IdProveedor);
                    comando.Parameters.AddWithValue("@NombreProveedor", proveedor.NombreProveedor);
                    comando.Parameters.AddWithValue("@Identidad", proveedor.Identidad);
                    comando.Parameters.AddWithValue("@RTN", proveedor.Rtn);
                    comando.Parameters.AddWithValue("@Direccion", proveedor.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", proveedor.Telefono);
                    comando.Parameters.AddWithValue("@Correo", proveedor.Correo);

                    try
                    {
                        conexion.Open();
                        int filasAfectadas = comando.ExecuteNonQuery();
                        actualizado = filasAfectadas > 0;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al actualizar proveedor: " + ex.Message);
                    }
                }
            }

            return actualizado;
        }
        //metodos de compras
        public DataRow? BuscarMaterial(string valor, string tipoBusqueda)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = tipoBusqueda == "id_material"
                    ? "SELECT id_accesorio as id_material, descripcion, 0.00 as precio FROM vwMateriales WHERE id_accesorio = @valor"
                    : "SELECT id_accesorio as id_material, descripcion, 0.00 as precio FROM vwMateriales WHERE descripcion LIKE @valor";

                using (SqlDataAdapter da = new SqlDataAdapter(query, conn))
                {
                    if (tipoBusqueda == "id_material")
                        da.SelectCommand.Parameters.AddWithValue("@valor", valor);
                    else
                        da.SelectCommand.Parameters.AddWithValue("@valor", "%" + valor + "%");

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                        return dt.Rows[0]; // si hay más, toma el primero
                }
            }
            return null;
        }



        //metodos generales
        public string devolverUnValor(string consulta)
        {
            string? valor = "";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                using (SqlCommand comando = new SqlCommand(consulta, conexion))
                {
                    try
                    {
                        conexion.Open();
                        object resultado = comando.ExecuteScalar();

                        if (resultado != DBNull.Value)
                        {
                            valor = resultado.ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener el valor: " + ex.Message);
                    }
                }
            }

            return valor!;
        }
        public DataTable LlenarTabla(string consultaSql)
        {
            DataTable tabla = new DataTable();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter adaptador = new SqlDataAdapter(consultaSql, conexion);
                    adaptador.Fill(tabla);

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al llenar tabla: " + ex.Message);
                }
            }

            return tabla;
        }
        public List<string> llenarCombobox(string consulta, string mensaje)
        {
            List<string> lista = new List<string>();

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(consulta, conexion))
            {
                try
                {
                    conexion.Open();
                    SqlDataReader lector = comando.ExecuteReader();
                    lista.Insert(0, mensaje);

                    while (lector.Read())
                    {
                        lista.Add(lector["Descripcion"].ToString());
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al llenar lista para ComboBox: " + ex.Message);
                }
            }
            return lista;
        }
        public void ReemplazarValorEnListas<T>(List<T> lista, string nombrePropiedad, object nuevoValor)
        {
            foreach (var item in lista)
            {
                var propiedad = typeof(T).GetProperty(nombrePropiedad);
                if (propiedad != null && propiedad.CanWrite)
                {
                    propiedad.SetValue(item, nuevoValor);
                }
            }
        }

        public bool InsertarAlgo(string consultaSql, Dictionary<string, object> parametros)
        {
            bool insertado = false;

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(consultaSql, conexion))
            {
                try
                {
                    conexion.Open();

                    // Agregar parámetros
                    foreach (var param in parametros)
                    {
                        comando.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }

                    int filasAfectadas = comando.ExecuteNonQuery();
                    insertado = filasAfectadas > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al ejecutar insert: " + ex.Message);
                }
            }

            return insertado;
        }
        private string EncriptarCadena(string cadena)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(cadena);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
        private bool VerificarClave(string claveIngresada, string claveHasheada)
        {
            string hashIngresado = EncriptarCadena(claveIngresada);
            return hashIngresado == claveHasheada;
        }




    }
}
