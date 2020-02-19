using System;
using System.Collections.Generic;
using SyStock.Entidades;
using SyStock.LogicaNegocio.ClasedeDominio;

namespace SyStock.LogicaNegocio
{
    public static class ControladorFachada
    {
        /// <summary>
        /// Almacena el ID del usuario que actualmente está utilizando la aplicación
        /// </summary>
        public static int IDUsuarioLogeado { get; set; }

        #region CONTROLADOR USUARIO

        /// <summary>
        /// Método para agrega un Usuario
        /// </summary>
        /// <param name="pNombre">Nombre de Usario</param>
        /// <param name="pContraseña">Contraseña del Usuario</param>
        /// <param name="EsAdmin">True si es admin, False si no lo es</param>
        /// <returns>Usuario agregado. Null si no se puede agregar</returns>
        public static Usuario AgregarUsuario(string pNombre, string pContraseña, bool EsAdmin)
        {
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));

            Usuario usuario = new Usuario(pNombre, hash, DateTime.Now);
            if (EsAdmin)
                usuario.IdUsuarioAdmin = 0;
            else
                usuario.IdUsuarioAdmin = IDUsuarioLogeado;

            if (ControladorUsuario.Agregar(usuario) == -1)
                return usuario;
            else
                return null;
        }

        /// <summary>
        /// Método para modificar un usuario
        /// </summary>
        /// <param name="pUsuario">Usuario a modificar</param>
        /// <param name="pContraseñaAntigua">Contraseña antigua</param>
        /// <param name="pContraseñaNueva">Nueva contraseña</param>
        /// <returns></returns>
        public static bool ModificarUsuario(Usuario pUsuario, string pContraseñaAntigua, string pContraseñaNueva)
        {
            if (pUsuario == null)
                throw new ArgumentNullException(nameof(pUsuario));

            Usuario usuario;
            if (pUsuario.IdUsuario == 0)
                usuario = ControladorUsuario.Obtener(IDUsuarioLogeado);
            else
            {
                usuario = ControladorUsuario.Obtener(pUsuario.Nombre);
                Console.Write(pUsuario.Nombre);
            }
            
            string hash = Utilidades.Encriptar(string.Concat(usuario.Nombre, pContraseñaAntigua));
            if (usuario.Contraseña != hash)
                return false;
            else
            {
                string hash_nuevo = Utilidades.Encriptar(string.Concat(usuario.Nombre, pContraseñaNueva));
                usuario.Contraseña = hash_nuevo;
                ControladorUsuario.Modificar(usuario);
                return true;
            }
        }

        /// <summary>
        /// Método para eliminar un usuario
        /// </summary>
        /// <param name="pNombreUsuario">Nombre del usuario a eliminar</param>
        /// <returns>Devuelve True si fue eliminado. False si no se pudo eliminar</returns>
        public static bool EliminarUsuario(string pNombreUsuario)
        {
            Usuario usuario;
            usuario = ControladorUsuario.Obtener(pNombreUsuario);
            if (usuario.FechaBaja == DateTime.MinValue)
            {
                usuario.FechaBaja = DateTime.Now;
                ControladorUsuario.Modificar(usuario);
                return true;
            }
            else
                return false;
            
        }

        /// <summary>
        /// Método para verificar si un usuario existe
        /// </summary>
        /// <param name="pNombre">Nombre del Usuario</param>
        /// <param name="pContraseña">Contraseña del Usuario</param>
        /// <returns>Devuelve el usuario. Null si no lo encontró</returns>
        public static int VerificarUsuario(string pNombre, string pContraseña)
        {
            if (string.IsNullOrEmpty(pNombre))
                pNombre = ControladorUsuario.Obtener(IDUsuarioLogeado).Nombre;

            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            Usuario usuario = ControladorUsuario.Verificar(pNombre, hash); //Trae un objeto nulo si no lo encontró

            if (usuario == null)
                return 1;
            else if (usuario.FechaBaja != DateTime.MinValue)
                return 2; // Ya se encuentra dado de baja 
            else
            {
                IDUsuarioLogeado = usuario.IdUsuario;
                return 3; // Puede loguearse
            }
        }

        /// <summary>
        /// Verifica si el usuario registrado es Administrador
        /// </summary>
        /// <returns>Devuelve True si es Administrado. False si no lo es</returns>
        public static bool EsAdmin()
        {
            Usuario usuario = ControladorUsuario.Obtener(IDUsuarioLogeado);
            if (usuario.IdUsuarioAdmin == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Método para listar los Usuarios
        /// </summary>
        /// <returns>Devuelve una lista de Usuarios</returns>
        public static List<Usuario> ListarUsuarios()
        {
            return ControladorUsuario.Listar();
        }
        #endregion

        #region CONTROLADOR CATEGORIA

        /// <summary>
        /// Agrega una categoría a la base de datos
        /// </summary>
        /// <param name="pNombre">Nombre de la categoria</param>
        /// <returns>-1 en caso de éxito</returns>
        public static int AgregarCategoria(string pNombre)
        {
            Categoria categoria = new Categoria(pNombre,true,IDUsuarioLogeado);
            return ControladorCategoria.Agregar(categoria);
        }

        /// <summary>
        /// Modifica el nombre de una categoría
        /// </summary>
        /// <param name="nombreAntigua">nombre anterior</param>
        /// <param name="nombreNuevo">nuevo nombre</param>
        /// <returns>True en caso de éxito. Falso caso contrario</returns>
        public static bool ModificarCategoria(string nombreAntigua, string nombreNuevo)
        {
            Categoria categoria;
            categoria = ControladorCategoria.Obtener(nombreAntigua);
            categoria.Nombre = nombreNuevo;
            return ControladorCategoria.Modificar(categoria);
        }

        /// <summary>
        /// Permite dar de baja una categoría
        /// </summary>
        /// <param name="pCategoria">Categoría a buscar</param>
        /// <returns>True en caso de éxito. False caso contrario</returns>
        public static bool BajaCategoria(Categoria pCategoria)
        {
            return ControladorCategoria.Baja(pCategoria);
        }

        /// <summary>
        /// Permite eliminar definitivamente una categoría
        /// </summary>
        /// <param name="pCategoria">Categoría a buscar</param>
        /// <returns>True en caso de éxito. False caso contrario</returns>
        public static bool EliminarCategoria(Categoria pCategoria)
        {
            return ControladorCategoria.Eliminar(pCategoria);
        }

        /// <summary>
        /// Lista las categorías existentes
        /// </summary>
        /// <returns>Lista conteniendo las categorías de la base de datos</returns>
        public static List<Categoria> ListarCategorias()
        {
            return ControladorCategoria.Listar();
        }
        #endregion

        #region CONTROLADOR INSUMOS

        /// <summary>
        /// Método para Agregar un nuevo insumo
        /// </summary>
        /// <param name="pNombre">Nombre del insumo</param>
        /// <param name="pDescripcion">Descripción del insumo</param>
        /// <param name="pCantidad">Cantidad del insumo</param>
        /// <param name="pStock">Stock del insumo</param>
        /// <param name="pCategoria">Id de la categoría del insumo</param>
        /// <returns></returns>
        public static int AgregarInsumo(string pNombre, string pDescripcion, string pCantidad, string pStock, string pCategoria)
        {
            int idCategoria = ControladorCategoria.Obtener(pCategoria).IdCategoria;
            Insumo insumo = new Insumo(pNombre, pDescripcion,Convert.ToInt32(pCantidad), Convert.ToInt32(pStock), true, idCategoria);
            return ControladorInsumo.Agregar(insumo);
        }

        /// <summary>
        /// Método para obtener un determinado insumo
        /// </summary>
        /// <param name="pNombre">Nombre del insumo</param>
        /// <returns></returns>
        public static Insumo ObtenerInsumo(string pNombre)
        {
            return ControladorInsumo.Obtener(pNombre);
        }

        /// <summary>
        /// Modificar un determinado insumo
        /// </summary>
        /// <param name="pInsumo">Id del insumo</param>
        /// <returns></returns>
        public static void ModificarInsumo(Insumo pInsumo)
        {
            ControladorInsumo.Modificar(pInsumo);
        }

        /// <summary>
        /// Método para sumar stock a un insumo
        /// </summary>
        /// <param name="pNombre">Nombre del insumo</param>
        /// <param name="pCantidad">Cantidad del insumo</param>
        /// <returns></returns>
        public static bool SumarStock(string pNombre, int pCantidad)
        {
            Insumo insumo = ControladorInsumo.Obtener(pNombre);
            insumo.Cantidad += pCantidad;
            ControladorInsumo.Modificar(insumo);
            return true;
        }

        /// <summary>
        /// Método para restar stock a un insumo
        /// </summary>
        /// <param name="pIns">Insumo a restar stock</param>
        /// <returns></returns>
        public static bool RestarStock(Insumo pIns)
        {
            if (pIns == null)
                throw new ArgumentNullException(nameof(pIns));

            Insumo insumo;
            insumo = ControladorInsumo.Obtener(pIns.IdInsumo);
            int cantidadActual = insumo.Cantidad - pIns.Cantidad;
            insumo.Cantidad = cantidadActual;
            ControladorInsumo.Modificar(insumo);
            return true;
        }

        /// <summary>
        /// Método para listar insumos
        /// </summary>
        /// <returns>Lista de insumos</returns>
        public static List<Insumo> ListarInsumos()
        {
            return ControladorInsumo.Listar();
        }

        /// <summary>
        /// Método para listar insumos
        /// </summary>
        /// <param name="pCategoria">Nombre de la categoría</param>
        /// <returns>Lista de insumos</returns>
        public static List<Insumo> ListarInsumos(string pCategoria)
        {
            Categoria categoria = ControladorCategoria.Obtener(pCategoria);
            return ControladorInsumo.Listar(categoria.IdCategoria);
        }
        #endregion

        #region CONTROLADOR AREA

        /// <summary>
        /// Método para agregar un área
        /// </summary>
        /// <param name="pNombreArea">Nómbre del área a agregar</param>
        /// <returns>Devuelve -1 si logra agregarla, o sino el ID del Área</returns>
        public static int AgregarArea(string pNombreArea)
        {
            Area area = new Area(pNombreArea);
            return ControladorArea.Agregar(area);
        }

        /// <summary>
        /// Método para modificar un área
        /// </summary>
        /// <param name="nombreAntigua">Nombre de la área a modificar</param>
        /// <param name="nombreNuevo">Nuevo nombre del área</param>
        /// <returns>Devuelve true si o modificò. False en caso contrario</returns>
        public static bool ModificarArea(string nombreAntigua, string nombreNuevo)
        {
            Area area = ControladorArea.Obtener(nombreAntigua);
            area.Nombre = nombreNuevo;
            return ControladorArea.Modificar(area);
        }

        /// <summary>
        /// Método para listar las áreas
        /// </summary>
        /// <returns>Devuelve una lista de áreas</returns>
        public static List<Area> ListarArea()
        {
            return ControladorArea.Listar();
        }
        #endregion

        #region CONTROLADOR GRUPO

        /// <summary>
        /// Método para agregar un´grupo
        /// </summary>
        /// <param name="pNombreGrupo">Nombre del grupo</param>
        /// <param name="pNombreArea">Nombre del área al q se le asignará el grupo</param>
        /// <returns>Devuelve -1 si agregó el Grupo. sino el valor del Id del grupo ya existente</returns>
        public static int AgregarGrupo(string pNombreGrupo, string pNombreArea)
        {
            Area _area = ControladorArea.Obtener(pNombreArea);
            Grupo _grupo = new Grupo(pNombreGrupo,true,_area.IdArea,IDUsuarioLogeado);
            return ControladorGrupo.Agregar(_grupo);
        }

        /// <summary>
        /// Método para modificar un grupo
        /// </summary>
        /// <param name="nombreAntigua">Nombre del grupo</param>
        /// <param name="nombreNuevo">Nuevo nombre del grupo</param>
        /// <returns>Devuelve true si logró modificarlo</returns>
        public static bool ModificarGrupo(string nombreAntigua, string nombreNuevo)
        {
            Grupo grupo = ControladorGrupo.Obtener(nombreAntigua);
            grupo.Nombre = nombreNuevo;
            return ControladorGrupo.Modificar(grupo);
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <returns>Lista de grupos</returns>
        public static List<Grupo> ListarGrupos()
        {
            return ControladorGrupo.Listar();
        }

        /// <summary>
        /// Método para listar los grupos
        /// </summary>
        /// <param name="pArea">Id del Área de os grupos a listar</param>
        /// <returns>Lista de grupos para una determinada Área</returns>
        public static List<Grupo> ListarGrupos(string pArea)
        { 
            Area area = ControladorArea.Obtener(pArea);
            return ControladorGrupo.Listar(area.IdArea);
        }
        #endregion

        #region CONTROLADOR PERSONA

        /// <summary>
        /// Permite agregar una persona
        /// </summary>
        /// <param name="pNombre">nombre de la persona</param>
        /// <param name="pContraseña">contraseña para permitir el retiro de insumos</param>
        /// <param name="pNombreGrupo">grupo al que pertenece</param>
        /// <returns>-1 en caso de éxito</returns>
        public static int AgregarPersona(string pNombre, string pContraseña, string pNombreGrupo)
        {
            int idPersona = ControladorPersona.VerificarNombre(pNombre);
            if (idPersona == -1)
            {
                string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));

                Grupo gr = ControladorGrupo.Obtener(pNombreGrupo);
                int idGrupo;
                if (gr != null)
                    idGrupo = gr.IdGrupo;
                else
                    return -2;

                PersonaAutorizada persona = new PersonaAutorizada(pNombre, hash, DateTime.Today, DateTime.Today, idGrupo);

                if (ControladorPersona.Agregar(persona) == -2)
                    idPersona = -2;
            }
            return idPersona;
        }

        /// <summary>
        /// Verifica las credenciales de una persona
        /// </summary>
        /// <param name="pNombre">nombre de la persona</param>
        /// <param name="pContraseña">contraseña</param>
        public static int VerificarPersona(string pNombre, string pContraseña)
        {
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            return ControladorPersona.Verificar(pNombre, hash);
        }

        /// <summary>
        /// Verifica la existencia de una persona. Busca por nombre
        /// </summary>
        /// <param name="pNombre">nombre a buscar</param>
        public static int VerificarNombre(string pNombre)
        {
            return ControladorPersona.VerificarNombre(pNombre);
        }

        /// <summary>
        /// Permite modificar la contrasña de una persona
        /// </summary>
        /// <param name="pNombre">nombre de la persona</param>
        /// <param name="pContraseña">contraseña</param>
        public static bool ModificarPersona(string pNombre, string pContraseña)
        {
            PersonaAutorizada personaAutorizada = ControladorPersona.Obtener(pNombre);
            string hash = Utilidades.Encriptar(string.Concat(pNombre, pContraseña));
            personaAutorizada.Contraseña = hash;
            ControladorPersona.Modificar(personaAutorizada);
            return true;
        }

        /// <summary>
        /// Permite modificar el nombre y la contraseña de una persona
        /// </summary>
        /// <param name="pNombreAntiguo">nombre actual</param>
        /// <param name="pNombreNuevo">nuevo nombre</param>
        /// <param name="pContraseña">nueva contraseña</param>
        /// <returns></returns>
        public static bool ModificarPersona(string pNombreAntiguo, string pNombreNuevo, string pContraseña)
        {
            PersonaAutorizada personaAutorizada = ControladorPersona.Obtener(pNombreAntiguo);
            string hash = Utilidades.Encriptar(string.Concat(pNombreNuevo, pContraseña));
            personaAutorizada.Nombre = pNombreNuevo;
            personaAutorizada.Contraseña = hash;
            ControladorPersona.Modificar(personaAutorizada);
            return true;
        }

        /// <summary>
        /// Genera una lista de personas
        /// </summary>
        /// <returns>Lista conteniendo todas las personas autorizadas</returns>
        public static List<PersonaAutorizada> ListarPersonas()
        {
            return ControladorPersona.Listar();
        }

        /// <summary>
        /// Genera una lista de personas
        /// </summary>
        /// <param name="pGrupo">grupo de pertenencia</param>
        /// <returns>Lista conteniendo todas las personas de un determinado grupo</returns>
        public static List<PersonaAutorizada> ListarPersonas(string pGrupo)
        {
            int idGrupo = ControladorGrupo.Obtener(pGrupo).IdGrupo;
            return ControladorPersona.Listar(idGrupo);
        }

        /// <summary>
        /// Genera una lista de las personas en Alta
        /// </summary>
        /// <returns>Lista conteniendo todas las personas cuyo estado actual es "Alta"</returns>
        public static List<MostrarPersonas> MostrarPersonas()
        {
            List<PersonaAutorizada> lista;
            List<MostrarPersonas> listaMostrar = new List<MostrarPersonas>();

            lista = ControladorPersona.Listar();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].FechaAlta >= lista[i].FechaBaja)
                {
                    Grupo grupo = ControladorGrupo.Obtener(lista[i].IdGrupo);
                    string area = ControladorArea.Obtener(grupo.IdArea).Nombre;
                    MostrarPersonas per = new MostrarPersonas(lista[i].IdPersona, lista[i].Nombre, grupo.Nombre, area);
                    listaMostrar.Add(per);
                }
            }

            return listaMostrar;
        }

        /// <summary>
        /// Genera una lista de las personas en Alta en un determinado grupo
        /// </summary>
        /// <param name="pArea">Area de la persona</param>
        /// <param name="pGrupo">Grupo de la persona</param>
        /// <returns>Lista conteniendo todas las personas cuyo estado actual es "Alta", dentro de un determinado grupo</returns>
        public static List<MostrarPersonas> MostrarPersonas(string pArea, string pGrupo)
        {
            if (pArea == null || pGrupo == null)
                throw new ArgumentNullException(pArea == null ? nameof(pArea) : nameof(pGrupo));

            List<PersonaAutorizada> lista;
            List<MostrarPersonas> listaMostrar = new List<MostrarPersonas>();

            lista = ControladorPersona.Listar();

            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].FechaAlta == lista[i].FechaBaja)
                {
                    Grupo grupo = ControladorGrupo.Obtener(lista[i].IdGrupo);
                    string area = ControladorArea.Obtener(grupo.IdArea).Nombre;
                    if ((pArea.Length == 0) && (area == pArea))
                    {
                        MostrarPersonas per = new MostrarPersonas(lista[i].IdPersona, lista[i].Nombre, grupo.Nombre, area);
                        listaMostrar.Add(per);
                    }
                    if ((pGrupo.Length == 0) && (grupo.Nombre == pGrupo))
                    {
                        MostrarPersonas per = new MostrarPersonas(lista[i].IdPersona, lista[i].Nombre, grupo.Nombre, area);
                        listaMostrar.Add(per);
                    }
                }
            }

            return listaMostrar;
        }

        /// <summary>
        /// Permite dar de baja una persona
        /// </summary>
        /// <param name="pNombre">nombre de la persona a dar de baja</param>
        /// <returns>true en caso de éxito, false caso contrario</returns>
        public static bool EliminarPersona(string pNombre)
        {
            PersonaAutorizada persona = ControladorPersona.Obtener(pNombre);
            if (persona.FechaBaja == DateTime.MinValue)
            {
                persona.FechaBaja = DateTime.Now;
                ControladorPersona.Modificar(persona);
                return true;
            }
            else
                return false;
        }
        #endregion

        #region CONTROLADOR ENTREGA

        /// <summary>
        /// Agrega una entrega
        /// </summary>
        /// <param name="nombrePersona">nombre de la persona que retira</param>
        public static int AgregarEntrega(string nombrePersona)
        {
            int idPersona = ControladorPersona.Obtener(nombrePersona).IdPersona;
            EntregaInsumos entrega = new EntregaInsumos(IDUsuarioLogeado, idPersona, DateTime.Today);
            return ControladorEntrega.Agregar(entrega);
        }
        #endregion

        #region CONTROLADOR RENGLON DE ENTREGA

        /// <summary>
        /// Permite agregar un renglón de entrega
        /// </summary>
        /// <param name="pIdEntrega"></param>
        /// <param name="listarInsumos"></param>
        /// <returns></returns>
        public static int AgregarRenglon(int pIdEntrega, List<Insumo> listarInsumos)
        {
            if (listarInsumos == null)
                throw new ArgumentNullException(nameof(listarInsumos));

            int idRenglon = 0;
            foreach (var ins in listarInsumos)
            {
                if ((ins != null) && (idRenglon != -2))
                {
                    if (RestarStock(ins))
                    {
                        RenglonEntrega renglon = new RenglonEntrega(pIdEntrega, ins.IdInsumo, ins.Cantidad);
                        idRenglon = ControladorRenglones.Agregar(renglon);
                    }
                    else
                    {
                        idRenglon = -2;
                    }
                }
            }
            return idRenglon;
        }
        #endregion
    }
}
