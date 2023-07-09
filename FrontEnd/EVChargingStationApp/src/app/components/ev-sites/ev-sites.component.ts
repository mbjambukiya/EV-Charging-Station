import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { ChargingSocket } from 'src/app/models/charging-socket.model';
import { EvSite } from 'src/app/models/ev-site.model';
import { Receipt } from 'src/app/models/receipt.model';
import { EvSiteService } from 'src/app/services/ev-site.service';

@Component({
  selector: 'app-ev-sites',
  templateUrl: './ev-sites.component.html',
  styleUrls: ['./ev-sites.component.css']
})
export class EvSitesComponent implements OnInit, OnDestroy {
  constructor(private evsiteService: EvSiteService) { }

  sitesList: EvSite[] | undefined
  chargingSocketsList: ChargingSocket[] | undefined
  receipt: Receipt | undefined

  subscription1: Subscription | undefined
  subscription4: Subscription | undefined
  subscription3: Subscription | undefined
  subscription2: Subscription | undefined

  selectedSite: number = 0
  ngOnInit(): void {
    //fetch sites list from backend using service
    this.subscription1 = this.evsiteService.getAllSites().subscribe((res) => {
      this.sitesList = res
    });
  }

  //fetch sockets list from backend using service based on selected site
  getChargingSockets() {
    this.subscription2 = this.evsiteService.getChargingSockets(this.selectedSite).subscribe((res) => {
      this.chargingSocketsList = res;
    });
  }

  //lock socket and start charging
  lockSocket(socketId: number) {
    var lockSocketModel = { socketId: socketId, userId: 1 };
    this.subscription3 = this.evsiteService.putLockSocket(lockSocketModel).subscribe((res) => {
      this.getChargingSockets()
    });
  }

  //complete charging and unlock socket
  unLockSocket(socketId: number) {
    var lockSocketModel = { socketId: socketId, userId: 1 };
    this.subscription4 = this.evsiteService.putUnLockSocket(lockSocketModel).subscribe((res) => {
      this.receipt = res
      this.getChargingSockets()
    });
  }

  //close reciept details
  hideReceipt() {
    this.receipt = undefined
  }

  ngOnDestroy(): void {
    //unsubscribing subscriptions
    if (this.subscription1) {
      this.subscription1.unsubscribe();
    }
    if (this.subscription2) {
      this.subscription2.unsubscribe();
    }
    if (this.subscription3) {
      this.subscription3.unsubscribe();
    }
    if (this.subscription4) {
      this.subscription4.unsubscribe();
    }
  }
}
