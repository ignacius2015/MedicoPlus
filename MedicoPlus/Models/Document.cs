using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoPlus.Models
{
    public class Document
    {
        public string Name { get; }//текст ссылки
        public string ImageName { get; }//картинка на кнопке
        public string ModuleName { get; }// название модуля для загрузки
                                       //вся инфа хранится в XML - файле с номером доступа

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(Document) && Equals((Document)obj);
        }

        private bool Equals(Document other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(other.Name, Name);
        }

        public static explicit operator Document(string v)
        {
            throw new NotImplementedException();
        }
       
    }
}
