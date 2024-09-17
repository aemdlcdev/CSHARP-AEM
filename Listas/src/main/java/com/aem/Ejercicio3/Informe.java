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
public class Informe {
    
    public final String[] tareas={"administrativo", "empresarial", "personal"};
    private int codigo;
    private String tarea;
    
    public Informe(int codigo,int indiceTarea){
        this.codigo= codigo;
        this.tarea= this.tareas[indiceTarea];
    }
    public int getCodigo() {
        return codigo;
    }
    public void setCodigo(int codigo) {
        this.codigo = codigo;
    }
    public String getTarea() {
        return tarea;
    }
    public void setTarea(String tarea) {
        this.tarea = tarea;
    }
    public String[] getTareas(){
        return tareas;
    }
    @Override
    public String toString(){
        return "El informe con codigo "+codigo+" tiene la tarea de "+tarea;
    }
    
}
