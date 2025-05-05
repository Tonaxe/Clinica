#  Clínica

Repositorio del sistema de gestión para una clínica odontológica. Este proyecto modela la estructura principal de usuarios, pacientes, visitas y tratamientos dentro de una clínica, con un enfoque orientado a objetos y preparado para integración con base de datos y lógica de negocio.

 **Repositorio:** `git@github.com:Tonaxe/Clinica.git`

---

##  Arquitectura del Sistema

El sistema está diseñado con una arquitectura orientada a objetos, centrada en la reutilización de código y una estructura robusta para gestión de usuarios y visitas.

###  Clases Principales

- **Usuario (abstracta)**  
  Clase base con atributos comunes: `nombre`, `correo`, `contraseña`.  
  Subclases:
  - **Administrativo**: Gestiona pacientes y visitas.
  - **Odontólogo**: Tiene `especialidad`, `horario` y puede prescribir tratamientos.

- **Paciente**  
  Contiene `datos personales`, `tipo de pago` y, si es menor de edad, se relaciona con un **Responsable**.  
  - Método destacado: `esMayorDeEdad()`.

- **Visita**  
  Relaciona **Paciente** y **Odontólogo**, incluye:
  - `motivo`, `observaciones`, `tratamientos`.
  - Métodos para registrar observaciones y prescripciones.

- **Horario**  
  Define disponibilidad de los odontólogos:
  - Atributos: `días`, `horas`.
  - Validación de disponibilidad.

- **Enumeraciones**
  - `DíaSemana`: Lunes a Domingo.
  - `TipoPago`: Efectivo, Tarjeta, Seguro, etc.




---


##  Requisitos

Antes de comenzar, asegúrate de tener instalados los siguientes programas:

- [**Node.js**](https://nodejs.org/)  
  Necesario para ejecutar el frontend.

- [**Visual Studio 2022**](https://visualstudio.microsoft.com/es/)  
  Requerido para ejecutar y recompilar la API.

- [**Git**](https://git-scm.com/)  
  Para clonar el repositorio y trabajar con el control de versiones.

---

##  Clonar el repositorio

```bash
git clone https://github.com/Tonaxe/Clinica.git
cd Clinica
