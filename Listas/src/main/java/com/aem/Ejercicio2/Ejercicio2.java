/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.aem.Ejercicio2;

import com.aem.listas.ListaEnlazada;

/**
 *
 * @author AEM by Alejandro Esteban Martinez de la Casa
 * @version 1.0
 * Created on 17 sept 2024
 *
 */
public class Ejercicio2 {
    public static void main (String[] args){
        /**
         * La aplicación debe almacenar Productos (clase), cada producto al crearse
            contiene una cantidad, un precio (estos dos generados aleatoriamente). El
            nombre del producto será básico (producto1, producto2, producto3, etc.).
            Se proporciona la clase Producto, solo agrégala a tu proyecto.
            El precio ya viene con los impuestos incluidos.

            Calcular el precio total de una lista de entre 1 y 8 productos (aleatorio).
            Mostrar un ticket con todo lo vendido y el precio final como se hacen en los
            supermercados. Más o menos con este formato, lo importante son los datos,
            no el estilo
         */
        
        ListaEnlazada<Producto> lista = new ListaEnlazada<Producto>();
        
        int numProductos=generaRandom(1,8);
        
        int cantidad;
        double precio=generaNumeroRealAleatorio(1,20);
        
        for(int i=0;i<numProductos;i++){
            cantidad=generaRandom(1,50);
            precio=generaRandom(1,20);
            Producto p = new Producto(cantidad,precio);
            lista.introducirDato(i, p);
        }
        
        double precioTotal=0;
        
        for(int i=0;i<lista.cuantosElementos();i++){
            precioTotal=lista.devolverDato(i).getCantidad()*lista.devolverDato(i).getPrecio();
        }
        System.out.println("Lista productos:");
        for(int i=0;i<lista.cuantosElementos();i++){
            System.out.println("Producto"+i+" Cantidad: "+lista.devolverDato(i).getCantidad() + " Precio: "+lista.devolverDato(i).getPrecio());
        }
        System.out.println("Total recaudado: " + precioTotal + " euros");
    }
    
    public static int generaRandom(int min, int max){
        int num = (int)(Math.floor(Math.random()*(min-max+1))+(max+1));
        return num;
    }
    
    public static double generaNumeroRealAleatorio(double minimo, double maximo){
        double num=Math.rint(Math.floor(Math.random()*(minimo-
        ((maximo*100)+1))+((maximo*100)+1)))/100;
        return num;
    }
}
