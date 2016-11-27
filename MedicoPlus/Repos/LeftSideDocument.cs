using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicoPlus.Repos
{
    public class LeftSideDocument
    {
        public string LinkName { get; set; } //текст ссылки
        public string ModuleName { get; set; }// название модуля для загрузки
        public string Hint { get; set; }//всплывающее сообщение

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == typeof(LeftSideDocument) && Equals((LeftSideDocument)obj);
        }

        private bool Equals(LeftSideDocument other)
        {
            if (ReferenceEquals(null, other)) return false;
            return ReferenceEquals(this, other) || Equals(other.ModuleName, ModuleName);
        }

        public static explicit operator LeftSideDocument(string v)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            return ModuleName?.GetHashCode() ?? 0;
        }
    }
}
