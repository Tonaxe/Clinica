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

##  Diagrama UML

El diseño está representado en un diagrama UML que ilustra las relaciones entre clases: herencias, asociaciones y composición. Esto facilita la expansión del sistema hacia una base de datos y la conexión con interfaces gráficas o APIs.


---

##  Tecnologías sugeridas

Este sistema está preparado para integrarse con tecnologías como:

- **Java/Python** para la lógica del sistema.
- **MySQL/PostgreSQL** para la base de datos.
- **Spring Boot/Django** para desarrollo web.
- **React/Vue** para el frontend.

---

##  Clonar el repositorio

```bash
git clone git@github.com:Tonaxe/Clinica.git
cd Clinica
