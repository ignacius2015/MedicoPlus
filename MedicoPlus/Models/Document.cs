using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoPlus.Models
{
    public class Document
    {
        public string LinkName { get; set; } //текст ссылки
        public string ImageName { get; set; }//картинка на кнопке
        public string ModuleName { get; set; }// название модуля для загрузки
                                       //вся инфа хранится в XML - файле с номером доступа
        public int count { get; set; }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Document) && Equals((Document)obj);
        }

        private bool Equals(Document other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(other.ModuleName, ModuleName);
        }

        public static explicit operator Document(string v)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return ModuleName?.GetHashCode() ?? 0;
        }
    }
}
