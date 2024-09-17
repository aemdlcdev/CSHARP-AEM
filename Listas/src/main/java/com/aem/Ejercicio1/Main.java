/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.aem.Ejercicio1;

import com.aem.Ejercicio1.Persona;
import com.aem.listas.ListaEnlazada;

/**
 *
 * @author AEM by Alejandro Esteban Martinez de la Casa
 * @version 1.0
 * Created on 16 sept 2024
 *
 */
public class Main {
    public static void main (String[] args){
        /**
         * 
        Un conjunto de personas esperaran la cola para sacar una entrada, tendremos
        que calcular la entrada según la edad de la persona (mínimo 5 años).
        * 
        La edad de las personas se generan aleatoriamente entre 5 y 60 años. Es
        conveniente desarrollar un método principal para generar Personas en la cola.
        * 
        Al final, deberemos mostrar la cantidad total recaudada. El número de
        personas de la cola se elige al azar entre 0 y 50.
         */
        
        ListaEnlazada<Persona> listaPersonas = new ListaEnlazada<Persona>();
        
        int numPersonas = generaRandom(0,5);
        
        for(int i=0;i<=numPersonas;i++){
            Persona p = new Persona(generaRandom(5,60));
            listaPersonas.introducirDato(i, p);
        }
        
        double unEuro=0;
        double dosEuro=0;
        double tresEuro=0;
        
        for(int i=0;i<listaPersonas.cuantosElementos();i++){
            System.out.println(listaPersonas.devolverDato(i).getEdad());
        }
        
        for(int i=0;i<listaPersonas.cuantosElementos();i++){
            int edad=listaPersonas.devolverDato(i).getEdad();
            if(calculaPrecioEntrada(edad)==1.0){
                unEuro+=1.0;
            }
            else if(calculaPrecioEntrada(edad)==2.5){
                dosEuro+=2.5;                
            }
            else if(calculaPrecioEntrada(edad)==3.5){
                tresEuro+=3.5;  
            }
            
        }
        
        double total=unEuro+dosEuro+tresEuro;
        System.out.println("Recaudacion entre 5 y 10 anios "+unEuro+" euros");
        System.out.println("Recaudacion entre 11 y 17 anios "+dosEuro+" euros");
        System.out.println("Recaudacion mayores de 18 anios "+tresEuro+" euros");
        System.out.println("Total recaudado: " + total + " euros" );
        
       
       //Vacío la lista ya que todos han pagado y se han calculado las ganancias
       for (int i=0;i<listaPersonas.cuantosElementos();i++){
           listaPersonas.borraPosicion(i);
       }
       listaPersonas.quitarPrimero();
       listaPersonas.quitarUltimo();
       //Compruebo que la lista esté vacía
       for (int i=0;i<listaPersonas.cuantosElementos();i++){
           System.out.println(listaPersonas.devolverDato(i).getEdad());
       }
        
    }
    
    
    public static int generaRandom(int min, int max){
        int num = (int)(Math.floor(Math.random()*(min-max+1))+(max+1));
        return num;
    }
    
    public static double calculaPrecioEntrada(int edad){
        if(edad>=5 && edad <=10){
            return 1.0;
        }
        else if (edad>=11 && edad <=17){
            return 2.5;
        }
        else if(edad>=18){
            return 3.5;
        }
        else{
            return 0;
        }
    }
}
