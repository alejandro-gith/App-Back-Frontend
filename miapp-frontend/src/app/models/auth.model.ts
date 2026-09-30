export interface LoginRequest {
  username: string;
  password: string;
}

export interface LoginResponse {
  id: string;
  username: string;
  email: string;
  role: 'Administrador' | 'Cliente' | 'Auditor';
  token: string;
}

export interface LogoutResponse {
  success: boolean;
  message: string;
}
