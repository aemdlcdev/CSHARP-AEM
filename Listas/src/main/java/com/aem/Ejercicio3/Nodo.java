/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 */

package com.aem.Ejercicio3;

/**
 *
 * @author AEM by Alejandro Esteban Martinez de la Casa
 */
public class Nodo<T> {
    //Atributos
    private T elemento;
    private Nodo<T>siguiente; //Apunta al siguiente nodo
    
    //Constructor
    public Nodo(T elemento, Nodo<T>siguiente){
        this.elemento=elemento;
        this.siguiente=siguiente;
    }
    
    //Metodos
    
    public T getElemento(){
        return elemento;
    }
    
    public void setElemento(T elemento){
        this.elemento=elemento;
    }
    
    public Nodo<T>getSiguiente(){
        return siguiente;
    }
    
    public void setSiguiente(Nodo<T>siguiente){
        this.siguiente=siguiente;
    }
    
    @Override
    public String toString(){
        return elemento+"\n";
    }
    
}
