import { Injectable } from '@angular/core';

declare let alertify: any;

@Injectable({
  providedIn: 'root'
})

export class AlertifyService {

  constructor() { }
  success(message:string | null){
    if(message==null){return;}
    alertify.success(message)
  }
  error(message:string | null){
    if(message==null){return;}
    alertify.error(message)
  }
  errorCenter(message:string | null ){
    alertify.set('notifier','delay', 3);
    alertify.set('notifier','position', 'bottom-center');
    if(message==null){return;}
    alertify.error(message)
  }
  warning(message:string | null){
    if(message==null){return;}
    alertify.warning(message)
  }
}
