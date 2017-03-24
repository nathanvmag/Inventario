using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventario
{
    class Itens
    {

        public string Name;
        public int Quant;
        public Itens next;
        public Itens(string name, int quantidade)
        {
            Name = name;
            Quant = quantidade;
        }

    }
    class Program
    {

        static void Main(string[] args)
        {

            string[] Itensname = new string[10] { "Espada", "Faca", "Poção", "Arma", "Dinamite", "Luva", "Matrix", "Pokebola", "Chinelo", "Shuriken" };
            Itens[] temp = new Itens[10];
            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = new Itens(Itensname[i], 3);
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (i != temp.Length - 1)
                {
                    temp[i].next = temp[i + 1];
                    //Console.WriteLine(temp[i].next.Name);
                }
            }
            while (true)
            {
                Console.WriteLine("Digite o item a ser usado");
                string item = Console.ReadLine();
                UseIten(temp[0], item);
                Console.WriteLine("Ver Inventario ? s/n");
                string question = Console.ReadLine();
                if (question.ToLower() == "s")
                {
                    SeeInvetory(temp[0]);
                }
                Console.WriteLine("Espaço para continuar");
                Console.ReadKey();
                Console.Clear();            
            }
        }
       public static void SeeInvetory(Itens first)
        {
            Itens currentIten = first;
            int posi = 0;

       
            while (currentIten != null)
            {
                //PRECISA DE POSIÇÂO
                if (currentIten.Quant > 0)
                {
                    Console.WriteLine("Você tem " + currentIten.Quant + " " + currentIten.Name + " na posição " + posi);
                    posi++;
                }              
                     
                currentIten = currentIten.next;
                }
        }
        public static void UseIten(Itens first, string iten)
        {
            Itens currentIten = first;
            bool achou = false;
            while (currentIten != null)
            {
                if (currentIten.Name.ToLower() == iten.ToLower())
                {
                    if (currentIten.Quant - 1 == 0)
                    {
                        currentIten.Quant--;
                        Console.WriteLine("O Item " + currentIten.Name+" acabou");
                        removeIten(first, iten);
                        achou = true;
                    }
                    else if(currentIten.Quant-1>0)
                    {
                        currentIten.Quant--;
                        Console.WriteLine("Gastou um item " + currentIten.Name +" e restou "+currentIten.Quant);
                        achou = false;
                    }
                    else
                    {
                        Console.WriteLine("Item não encotrado");
                        achou = false;
                    }

                }                  
                       currentIten = currentIten.next;              
                }
            if (!achou) Console.WriteLine("Item não encontrado");
            first = currentIten;
        }
        public static void removeIten(Itens first, string Name)
        {
            Itens currentIten = first;
            Itens newlist = currentIten;
           
            while (currentIten != null && currentIten.next != null)
            {
                if (currentIten.next.Name.ToLower() == Name.ToLower() || currentIten.Name.ToLower() == Name.ToLower())
                {
                   
                    currentIten = currentIten.next.next;
                    
                }
                else
                {
                   
                    currentIten = currentIten.next;
                }
                


            }
        }
          

    }
    
}
