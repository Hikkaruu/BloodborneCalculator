import { Component, OnInit } from '@angular/core';
import { StatsForWeaponsService } from '../../services/stats-for-weapons.service';
import { StatsForWeapons } from '../../models/stats-for-weapons.model';

@Component({
  selector: 'app-stats-for-weapons',
  templateUrl: './stats-for-weapons.component.html',
  styleUrls: ['./stats-for-weapons.component.css'],
  standalone: true,
  imports: [],
})
export class StatsForWeaponsComponent implements OnInit {
  stats!: StatsForWeapons;

  constructor(private statsForWeaponsService: StatsForWeaponsService) {}

  ngOnInit(): void {
    this.statsForWeaponsService.stats$.subscribe(() => {
      this.stats = this.statsForWeaponsService.getCurrentStats();
    });

    const newStats: StatsForWeapons = {
      strength: 10,
      skill: 10,
      bloodtinge: 10,
      arcane: 10,
      upgradeLevel: 0,
    };
    this.statsForWeaponsService.setStats(newStats);
  }

  increaseStat(statName: keyof StatsForWeapons, max: number): void {
    if (this.stats[statName] < max) {
      this.stats[statName]++;
      this.statsForWeaponsService.setStats(this.stats);
    }
  }

  decreaseStat(statName: keyof StatsForWeapons, min: number): void {
    if (this.stats[statName] > min) {
      this.stats[statName]--;
      this.statsForWeaponsService.setStats(this.stats);
    }
  }

  validateStat(
    statName: keyof StatsForWeapons,
    event: Event,
    min: number,
    max: number
  ): void {
    const input = event.target as HTMLInputElement;
    let value = parseInt(input.value, 10);

    if (isNaN(value)) value = min;
    if (value < min) value = min;
    if (value > max) value = max;

    this.stats[statName] = value;
    input.value = value.toString();
    this.statsForWeaponsService.setStats(this.stats);
  }
}
