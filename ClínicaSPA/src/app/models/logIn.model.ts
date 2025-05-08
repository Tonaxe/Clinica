export interface LogInRequest {
    email: string,
    password: string,
}

export interface LogInResponse {
    user: User,
    message: string,
}

export interface User {
    id: number,
    nombre: string,
    apellido: string,
    email: string,
    rol: string,
    imagen: string,
}