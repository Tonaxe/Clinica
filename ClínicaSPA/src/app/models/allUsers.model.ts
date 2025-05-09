import { User } from "./user.model";

export interface AllUsersResponse {
    usuarios: User[];
    message: string;
  }
  