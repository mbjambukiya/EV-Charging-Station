import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environment/environment';
import { EvSite } from '../models/ev-site.model';
import { ChargingSocket } from '../models/charging-socket.model';
import { Receipt } from '../models/receipt.model';
import { LockSocket } from '../models/lock-socket.model';

@Injectable({
  providedIn: 'root'
})
export class EvSiteService {

  constructor(private http: HttpClient) { }

  getAllSites(): Observable<EvSite[]> {
    return this.http.get<EvSite[]>(environment.apiUrl + "api/EvSites")
  }

  getChargingSockets(siteId: number): Observable<ChargingSocket[]> {
    return this.http.get<ChargingSocket[]>(environment.apiUrl + "api/EvSites/" + siteId)
  }

  putLockSocket(lockSocketModel: LockSocket) {
    return this.http.put(environment.apiUrl + "api/EvSites/lock-socket", lockSocketModel)
  }

  putUnLockSocket(lockSocketModel: LockSocket): Observable<Receipt> {
    return this.http.put<Receipt>(environment.apiUrl + "api/EvSites/unlock-socket", lockSocketModel)
  }
}
