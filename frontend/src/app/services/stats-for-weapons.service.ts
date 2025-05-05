import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { StatsForWeapons } from '../models/stats-for-weapons.model';

@Injectable({
  providedIn: 'root',
})
export class StatsForWeaponsService {
  private statsSubject = new BehaviorSubject<StatsForWeapons>({
    strength: 10,
    skill: 10,
    bloodtinge: 10,
    arcane: 10,
    upgradeLevel: 0,
  });

  stats$ = this.statsSubject.asObservable();

  setStats(stats: StatsForWeapons): void {
    this.statsSubject.next(stats);
  }

  getCurrentStats(): StatsForWeapons {
    return this.statsSubject.getValue();
  }
}
