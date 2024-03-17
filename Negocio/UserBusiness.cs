using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Dominio;

namespace Negocio
{
    public class UserBusiness
    {
        private DataAccess data;

        public UserBusiness()
        {
            data = new DataAccess();
        }

        public User Login(User user)
        {
            try
            {
                data.setQuery("Select id, nombre, email, pass, apellido, urlImagenPerfil, admin from USERS where email = @email AND pass = @pass");
                data.setParam("@email", user.Email);
                data.setParam("@pass", user.Password);
                data.executeRead();
                
                if(data.Reader.Read())
                {
                    user.Id = (int)data.Reader["id"];
                    if (!(data.Reader["nombre"] is DBNull)) {
                        user.Name = (string)data.Reader["name"];
                    }
                    if (!(data.Reader["apellido"] is DBNull)){
                        user.Surname = (string)data.Reader["apellido"];
                    }
                    if (!(data.Reader["urlImagenPerfil"] is DBNull)){
                        user.Surname = (string)data.Reader["urlImagenPerfil"];
                    }                    
                    user.Admin = (bool)data.Reader["admin"];

                    return user;
                }

                return null;

            } catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.closeConnection();
            }
        }

        public int Create(User user)
        {
            try
            {

                data.setQuery("Insert into USERS (email, pass, nombre, apellido, urlImagenPerfil, admin) output inserted.id values (@email, @pass, @nombre, @apellido, @urlImagenPerfil, @admin)");
                data.setParam("@email", user.Email);
                data.setParam("@pass", user.Password);
                data.setParam("@nombre", user.Name != "" ? user.Name : (Object)DBNull.Value);
                data.setParam("@urlImagenPerfil", user.UrlProfileImage != "" ? user.UrlProfileImage : (Object)DBNull.Value);
                data.setParam("@apellido", user.Surname != "" ? user.Surname : (Object)DBNull.Value);
                data.setParam("@admin", 0);

                return data.executeActionScalar();
            } catch (Exception ex)
            {
                throw ex;
            } finally {
                data.closeConnection();
            }
        }

        public void Update(User user)
        {
            try
            {

                data.setQuery("Update USERS set nombre = @nombre, apellido = @apellido, urlImagenPerfil = @urlImagenPerfil where id = @id");
                data.setParam("@nombre", user.Name != "" ? user.Name : (Object)DBNull.Value);
                data.setParam("@apellido", user.Surname != "" ? user.Surname : (Object)DBNull.Value);
                data.setParam("@urlImagenPerfil", user.UrlProfileImage != "" ? user.UrlProfileImage : (Object)DBNull.Value);
                data.executeAction();

            } catch (Exception ex)
            {
                throw ex;
            } finally
            {
                data.closeConnection();
            }
        }
    }
}
