import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Boss } from '../models/boss.model';

@Injectable({
  providedIn: 'root',
})
export class BossService {
  private selectedBossSubject = new BehaviorSubject<Boss | null>(null);
  selectedBoss$ = this.selectedBossSubject.asObservable();

  setSelectedBoss(boss: Boss) {
    this.selectedBossSubject.next(boss);
  }
}
