// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
//utilizar el paquete de list 
using System.Collections.Generic;

// PAQUETE JSON 
using System.Text.Json;
using System.Globalization;

//LEER ARCHIVOS

using System.IO;

//AGREGAR LA LIBRERIA DE LINQ
using System.Linq;
using System.Data.SqlClient;

namespace BaseDeDatos
{
    class Program
    {
        private static bool brands;

        // no puedo crear un objeto apartir de una clase abstracta

        static void Main(string[] args) 
        {
            try
            {
                // DB db = new DB("DESKTOP-94476DB", "CsharpDb", "sa", "guiamania");

                //db.Connect();

                //db.Close();

                BeerDB beerDB = new BeerDB("DESKTOP-94476DB", "CsharpDb", "sa", "guiamania");
                BrandDB brandDB = new BrandDB("DESKTOP-94476DB", "CsharpDb", "sa", "guiamania");




                bool again = true;
                int op = 0;

                do
                {
                    showMenu();
                    Console.WriteLine("Elige una Opcion:");
                    op = int.Parse(Console.ReadLine());

                    switch (op)
                    {
                        case 1:
                            show(beerDB);
                            //showbrond(brandDB);
                            break;
                        case 2:
                            Add(beerDB);
                            break;
                        case 3:
                            Edit(beerDB);
                            break;
                        case 4:
                            Delete(beerDB);
                            break;
                        case 5:
                            again = false;
                            break;
                    }

                }while(again);


               



            }catch (SqlException ex)
            {
                Console.WriteLine("No pudimos conectarnos");
            }
            
            
        }

        // metodo para mostrar lo que se escribio 

        public static void showMenu()
        {
            Console.WriteLine("\n-----------Menu------------");
            Console.WriteLine("1.- Motrar");
            Console.WriteLine("2.- Agregar");
            Console.WriteLine("3.- Editar");
            Console.WriteLine("4.- Eliminar");
            Console.WriteLine("5.- Salir");
        }

        // metodo 

        public static void show(BeerDB beerDB)
        {
            Console.Clear();
            
            List<Beer> beers = beerDB.GetAll();

            foreach (Beer beer in beers)
            {
                Console.WriteLine($"ID: {beer.Id} NOMBRE: {beer.Name} BrandID: {beer.BrandID} ");
            }
        }

        //metodo para agregar 

        public static void Add(BeerDB beerDB) 
        {
            Console.Clear();
            Console.WriteLine("Agregar nueva cerveza");
            Console.WriteLine("Escribe el nombre");
            string name  = Console.ReadLine();


            Console.WriteLine("Escribe el id de la marca:");

            
            int branid = int.Parse(Console.ReadLine());

            Beer beer = new Beer(name,branid);
            beerDB.Add(beer);
        }

        // metodo deditar 
        public static void Edit(BeerDB beerDB)
        {
            Console.Clear();
            show(beerDB);
            Console.WriteLine("Editar Cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a editar");
            int id = int.Parse(Console.ReadLine());

            Beer beer = beerDB.Get(id);

            if(beer != null) 
            {
                Console.WriteLine("Escribe el nombre:");
                string name = Console.ReadLine();
                Console.WriteLine("Escriba el id de la marca ");
                int branID= int.Parse(Console.ReadLine());

                beer.Name = name;
                beer.BrandID = branID;
                beerDB.Edit(beer);
            }
            else
            {
                Console.WriteLine("La cerveza no existe ");
            }


        }

        //metodo para mostrar tabla Brand
        public static void showbrond(BrandDB brandDB)
        {
            //Console.Clear();

          List<Brand> brands = brandDB.GetAllBrand();

            foreach (Brand brand in brands)
            {
                Console.WriteLine($"{brand.Id} {brand.Name}");
            }
        }

        //metodo de eliminar 

        public static void Delete(BeerDB beerDB)
        {
            Console.Clear();
       
            Console.WriteLine("Eliminar Cerveza");
            Console.WriteLine("Escribe el id de tu cerveza a eliminar");
            int id = int.Parse(Console.ReadLine());

            Beer beer = beerDB.Get(id);

            if (beer != null)
            {
                beerDB.Delete(id);
            }
            else
            {
                Console.WriteLine("La cerveza no existe ");
            }


        }


    }

 


}



