import { User } from "./user.model";

export interface LogInRequest {
    email: string,
    password: string,
}

export interface LogInResponse {
    user: User,
    message: string,
}