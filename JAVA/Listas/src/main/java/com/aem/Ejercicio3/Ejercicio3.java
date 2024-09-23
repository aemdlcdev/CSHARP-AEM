/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.aem.Ejercicio3;

/**
 *
 * @author AEM by Alejandro Esteban Martinez de la Casa
 * @version 1.0
 * Created on 17 sept 2024
 *
 */
public class Ejercicio3 {
    public static void main (String[] args){
        
        /**
         *  Un amigo funcionario nos pide que le hagamos un informe para sus
            informes.
            Debemos gestionar informes que están formados de un código
            numérico y una tarea que pueden ser ADMINISTRATIVO, EMPRESARIAL y
            PERSONAL. 
            
            Debe comprobarse que la tarea es alguna de estas.
            Nuestro amigo quiere que seamos capaz de agregar y eliminar informes en
            forma de pila (el último en entrar, es el primero en salir). Agrega 10 informes y
            muestra su contenido, elimina todo el contenido y agrega de nuevo 5
            informes.
             
            
            Puedes crear los informes como quieras.
            Copia la clase informe que se incluye de ayuda a continuación.

         */
        
        PilaDinamica<Informe> pila = new PilaDinamica<Informe>();
        int codigo;
        int tarea;
        for(int i=0;i<10;i++){
            codigo=generaRandom(1000,10000);
            tarea=generaRandom(0,2);
            Informe f = new Informe(codigo,tarea);
            if(compruebaTarea(f.getTarea())==false){
                System.out.println("Tarea invalida!");
            }
            else{
                pila.push(f);
            }
        }
        
        for(int i=0;i<10;i++){
            System.out.println("ID informe: "+pila.top().getCodigo());
            pila.pop();
        }
        
        for(int i=0;i<10;i++){
            pila.pop();
        }
        System.out.println("============");
        System.out.println("Pila nueva");
        System.out.println("============");
        for(int i=0;i<5;i++){
            codigo=generaRandom(1000,10000);
            tarea=generaRandom(0,2);
            Informe f = new Informe(codigo,tarea);
            if(compruebaTarea(f.getTarea())==false){
                System.out.println("Tarea invalida!");
            }
            else{
                pila.push(f);
            }
        }
        
        for(int i=0;i<5;i++){
            System.out.println("ID informe: "+pila.top().getCodigo());
            pila.pop();
        }
    }
    
    public static boolean compruebaTarea(String tarea){
        String str = tarea.toLowerCase();
        if(tarea.isBlank() || tarea.isEmpty()){
            return false;
        }
        else if(str.equals("administrativo") || str.equals("empresarial") || str.equals("personal")){
            return true;
        }
        else{
            return false;    
        }
    }
    
    
    public static int generaRandom(int min, int max){
        int num = (int)(Math.floor(Math.random()*(min-max+1))+(max+1));
        return num;
    }
}
