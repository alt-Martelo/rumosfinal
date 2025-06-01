import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TokenStorageService {
  private TOKEN_KEY = 'auth-token';
  private USER_KEY = 'auth-user';

  signOut(): void {
    window.sessionStorage.clear();
  }

  saveToken(token: string): void {
    window.sessionStorage.setItem(this.TOKEN_KEY, token);
  }

  getToken(): string | null {
    return window.sessionStorage.getItem(this.TOKEN_KEY);
  }

  saveUser(user: any): void {
    window.sessionStorage.setItem(this.USER_KEY, JSON.stringify(user));
  }

  getUser(): any {
    const user = window.sessionStorage.getItem(this.USER_KEY);
    return user ? JSON.parse(user) : null;
  }
}
