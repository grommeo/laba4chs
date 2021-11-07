using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace laba4chs
{

    public class Napitki 
    {
        public double Volume = 0; //объём
        public System.Drawing.Image img;
        public virtual String GetInfo()
        {
            var str = String.Format("\nОбъём: {0}", this.Volume);
            return str;
        }
        public static Random rnd = new Random();
    }
    public enum Fruitstype {apple, peach, pear, banana, multifruit};
    public class Sok : Napitki
    {
        public Fruitstype Type = Fruitstype.apple; //тип фрукта
        public bool WithPulp = false; //мякоть
        //public System.Drawing.Image img = ;

        public override String GetInfo()
        {
            var str = "Сок";
            str += base.GetInfo();
            str += String.Format("\nТип фрукта: {0}", this.Type);
            str += String.Format("\nНаличие мякоти: {0}", this.WithPulp);
            return str;
        }

        public static Sok Generate()
        {
            return new Sok
            {
                Volume = rnd.Next() % 101,
                Type = (Fruitstype)rnd.Next(5),
               WithPulp = rnd.Next() % 2 == 0,
                img = Properties.Resources.Sok
            };
        }
    }

    public enum Gaztype { low, medium, highly};
    public class Gazirovka : Napitki
    {
        public Gaztype Type2 = Gaztype.low; //вид
        public int Puziri = 0; //пузырьки
        public override String GetInfo()
        {
            var str = "Газировка";
            str += base.GetInfo();
            str += String.Format("\nГазированность: {0}", this.Type2);
            str += String.Format("\nПроцент пузырьков: {0}", this.Puziri);
            return str;
        }
        public static Gazirovka Generate()
        {
            return new Gazirovka
            {
                Volume = rnd.Next() % 101,
                Type2 = (Gaztype)rnd.Next(3),
                Puziri = rnd.Next() % 101,
                img = Properties.Resources.Газировка
        };
        }
    }

    public enum Alkotype { low, medium, highly };
    public class Alko : Napitki
    {
        public double krepost = 0; //крепкость напитка
        public Alkotype Type3 = Alkotype.low; //вид

        public override String GetInfo()
        {
            var str = "Алкоголь";
            str += base.GetInfo();
            str += String.Format("\nГрадус напитка: {0}", this.krepost);
            str += String.Format("\nВид напитка: {0}", this.Type3);
            return str;
        }
        public static Alko Generate()
        {
            return new Alko
            {
                Volume = rnd.Next() % 101,
                krepost =rnd.Next()%87,
                Type3 = (Alkotype)rnd.Next(3),
                img = Properties.Resources.Алкоголь
            };

        }
    }


}