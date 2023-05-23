using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Entities
{
    public partial class Tovar
    {
        public string AdminControlsVisiability
        {
            get
            {
                if (App.CurrentUser.RoleId == 1)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }
        public string UserControlsVisiability
        {
            get
            {
                if (App.CurrentUser.RoleId == 2)
                {
                    return "Visible";
                }
                else
                {
                    return "Collapsed";
                }
            }
        }
        public string BackColor
        {
            get
            {
                return "#0481CB";
            }
        }
        public string TotalCena
        {
            get
            {
                return $"{Cena:N2} рублей";
            }
        }
    }
}
