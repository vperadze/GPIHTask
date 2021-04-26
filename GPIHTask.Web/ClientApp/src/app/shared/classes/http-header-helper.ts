import { HttpHeaders } from "@angular/common/http";

export class HttpHeaderHelper {
  constructor() { }

  createDefaultHttpHeader() {
    //console.log("Token:", localStorage.getItem('token'));
    return new HttpHeaders({ /*'Authorization': 'Bearer ' + localStorage.getItem('token'),*/ 'Content-Type': 'application/json', })
  }
}
