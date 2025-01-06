import { CanActivateFn } from '@angular/router';
import { AccountService } from '../_services/account.service';
import { ToastrService } from 'ngx-toastr';
import { inject } from '@angular/core';

export const authGuard: CanActivateFn = (route, state) => {
  const accountservice = inject(AccountService);
  const toastrService = inject(ToastrService);

  if (accountservice.currentUser()) {
    return true;
  } else {
    toastrService.error('You shall not pass.');
    return false;
  }
};
