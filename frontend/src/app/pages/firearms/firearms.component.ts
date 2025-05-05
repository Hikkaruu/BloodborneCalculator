import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { BossPopupComponent } from '../boss-popup/boss-popup.component';
import { BossService } from '../../services/boss.service';
import { Boss } from '../../models/boss.model';
import { StatsForWeaponsComponent } from '../stats-for-weapons/stats-for-weapons.component';
import { StatsForWeaponsService } from '../../services/stats-for-weapons.service';
import { StatsForWeapons } from '../../models/stats-for-weapons.model';

interface Firearm {
  id: number;
  name: string;
  physicalAttack: number;
  bloodAttack: number;
  arcaneAttack: number;
  fireAttack: number;
  boltAttack: number;
  bulletUse: number;
  imprints: number;
  strengthRequirement: number;
  skillRequirement: number;
  bloodtingeRequirement: number;
  arcaneRequirement: number;
  imageUrl: string;
}

@Component({
  selector: 'app-firearms',
  standalone: true,
  imports: [CommonModule, BossPopupComponent, StatsForWeaponsComponent],
  templateUrl: './firearms.component.html',
  styleUrls: ['./firearms.component.css'],
})
export class FirearmsComponent implements OnInit {
  constructor(
    private http: HttpClient,
    private bossService: BossService,
    private statsForWeaponsService: StatsForWeaponsService
  ) {}

  stats!: StatsForWeapons;

  selectedBoss: Boss | null = null;
  firearms: Firearm[] = [];
  selectedFirearm: Firearm | null = null;
  showFirearmPopup = false;

  ngOnInit(): void {
    this.statsForWeaponsService.stats$.subscribe((stats) => {
      this.stats = stats;
      if (this.selectedFirearm) {
        this.calculateAttackRating();
        this.calculateDamage();
      }
    });

    this.bossService.selectedBoss$.subscribe((boss) => {
      this.selectedBoss = boss;

      if (this.selectedFirearm) {
        this.calculateAttackRating();
        this.calculateDamage();
      }
    });
  }

  loadFirearms(): void {
    this.http.get<Firearm[]>(`${environment.apiUrl}/api/Firearm`).subscribe({
      next: (data) => {
        this.firearms = data;
        this.showFirearmPopup = true;
      },
      error: (err) => console.error('Error loading firearms:', err),
    });
  }

  selectFirearm(firearm: Firearm): void {
    this.selectedFirearm = firearm;
    this.showFirearmPopup = false;
    this.calculateAttackRating();
    this.calculateDamage();
  }

  meetsRequirement(requirement: number, stat: number): boolean {
    return stat >= requirement;
  }

  attackRating: string = '';
  damage: string = '';

  calculateAttackRating(): void {
    if (!this.selectedFirearm) return;

    const url =
      `${environment.apiUrl}/api/Firearm/attack-rating/${this.selectedFirearm.id}?` +
      `strength=${this.stats.strength}&skill=${this.stats.skill}&` +
      `bloodtinge=${this.stats.bloodtinge}&arcane=${this.stats.arcane}&` +
      `weaponUpgradeLevel=${this.stats.upgradeLevel}`;

    this.http.get<any>(url).subscribe({
      next: (response) => {
        this.attackRating = response.attackRating;
      },
      error: (err) => {
        this.attackRating = '0';
        console.log(err.error);
      },
    });
  }

  calculateDamage(): void {
    if (!this.selectedFirearm || this.selectedBoss === null) return;

    const url =
      `${environment.apiUrl}/api/Damage/Firearm/${this.selectedFirearm.id}/Boss/${this.selectedBoss?.id}?` +
      `strength=${this.stats.strength}&skill=${this.stats.skill}&` +
      `bloodtinge=${this.stats.bloodtinge}&arcane=${this.stats.arcane}&` +
      `weaponUpgradeLevel=${this.stats.upgradeLevel}`;

    this.http.get<any>(url).subscribe({
      next: (response) => {
        this.damage = response.damage;
      },
      error: (err) => {
        this.damage = '0';
        console.log(err.error);
      },
    });
  }
}
