using System;
using System.Collections.Generic;
using System.Text;

namespace BUTTERPOP.modelo
{
    public class AdminAcces
    {
        string emailAdmin, passAdmin;
        bool respuesta;

  
        public AdminAcces() { }

        public void setEmailAdmin(string emailAdmin)
        {
            this.emailAdmin = emailAdmin;
        }

        public void setPassAdmin(string passAdmin)
        {
            this.passAdmin = passAdmin;
        }

        public void setRespuesta(bool respuesta)
        {
            this.respuesta = respuesta;
        }

        public string getEmailAdmin() { 
            return this.emailAdmin;
        }

        public string getPassAdmin() { 
            return this.passAdmin;
        }

        public bool getRespuesta() {
            return this.respuesta;
        }

        public bool verificarAccesoAdmin()
        {
            if (emailAdmin.Equals("admin_julian@butterpop.com") && passAdmin.Equals("Admin32@Julian") || 
                emailAdmin.Equals("admin_andy@butterpop.com") && passAdmin.Equals("Admin32@Andy") || 
                emailAdmin.Equals("admin_joel@butterpop.com") && passAdmin.Equals("Admin32@Joel") || 
                emailAdmin.Equals("admin_jesus@butterpop.com") && passAdmin.Equals("Admin32@Jesus") || 
                emailAdmin.Equals("admin_emmanuel@butterpop.com") && passAdmin.Equals("Admin32@Emmanuel"))
            {
                respuesta = true;
            } else
            {
                respuesta = false;
            }
            return respuesta;
        }

    }
}
