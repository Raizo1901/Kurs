using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ozon.Entities
{
    public partial class Zakaz
    {
        public string GetId
        {
            get
            {
                return $"Номер заказа: {Id_zakaz}";
            }
        }
        public string GetFIO
        {
            get
            {
                return $"ФИО: {Buyer.Familia} {Buyer.Ima} {Buyer.Otchestvo}";
            }
        }
        public string GetDate
        {
            get
            {
                return $"Дата покупки: " + Convert.ToDateTime(Date).ToString("dd MMMM yyyy");
            }
        }
        public string GetStatus
        {
            get
            {
                return $"Статус: {Status}";
            }
        }
        public string GetCost
        {
            get
            {
                return $"Стоимость: {Tovar.Cena * Quantity:N2} рублей";
            }
        }
        public string GetPoint
        {
            get
            {
                return $"Выдача в: Г.{Point_of_issue.City}, Ул.{Point_of_issue.Street}, Д.{Point_of_issue.house_number}";
            }
        }
        public string GetTovar
        {
            get
            {
                return $"Товар: {Tovar.Nazvanie}";
            }
        }
        public string GetQuantity
        {
            get
            {
                return $"Количество: {Quantity}";
            }
        }
        public string Print()
        {
            return $"Номер заказа: {Id_zakaz} \nФИО: {Buyer.Familia} {Buyer.Ima} {Buyer.Otchestvo} \nТовар: {Tovar.Nazvanie} \nКоличество: {Quantity} \nСтоимость: {Tovar.Cena * Quantity:N2} рублей \nДата покупки: {Convert.ToDateTime(Date).ToString("dd MMMM yyyy")} \nВыдача в: Г.{Point_of_issue.City}, Ул.{Point_of_issue.Street}, Д.{Point_of_issue.house_number} ";
        }
    }
}
