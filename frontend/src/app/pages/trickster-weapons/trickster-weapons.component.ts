import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { BossPopupComponent } from '../boss-popup/boss-popup.component';
import { BossService } from '../../services/boss.service';
import { Boss } from '../../models/boss.model';
import { StatsForWeaponsComponent } from '../stats-for-weapons/stats-for-weapons.component';
import { StatsForWeaponsService } from '../../services/stats-for-weapons.service';
import { StatsForWeapons } from '../../models/stats-for-weapons.model';
import { TricksterWeapon } from '../../models/trickster-weapon.model';
import { WeaponAttack } from '../../models/weapon-attack.model';

@Component({
  selector: 'app-trickster-weapons',
  imports: [StatsForWeaponsComponent, BossPopupComponent, CommonModule],
  templateUrl: './trickster-weapons.component.html',
  styleUrl: './trickster-weapons.component.css',
})
export class TricksterWeaponsComponent {
  constructor(
    private http: HttpClient,
    private bossService: BossService,
    private statsForWeaponsService: StatsForWeaponsService
  ) {}

  weaponImprints = {
    '2': [2, 2, 1],
    '3': [2, 2, 3],
    '4': [2, 2, 4],
    '5': [2, 3, 4],
  };

  stats!: StatsForWeapons;
  selectedBoss: Boss | null = null;
  tricksterWeapons: TricksterWeapon[] = [];
  selectedTricksterWeapon: TricksterWeapon | null = null;
  showTricksterWeaponPopup = false;
  selectedWeaponType: string = 'Normal';
  showDamagePopup = false;
  selectedWeaponAttacks: any[] = [];

  ngOnInit(): void {
    this.statsForWeaponsService.stats$.subscribe((stats) => {
      this.stats = stats;
      if (this.selectedTricksterWeapon) {
        this.calculateAttackRating();
        this.calculateDamage();
      }
    });

    this.bossService.selectedBoss$.subscribe((boss) => {
      this.selectedBoss = boss;

      if (this.selectedTricksterWeapon) {
        this.calculateAttackRating();
        this.calculateDamage();
      }
    });
  }

  getImprintImages(imprintValue: number): { id: number; value: number }[] {
    const imprintMap: Record<number, number[]> = {
      2: [2, 2, 1],
      3: [2, 2, 3],
      4: [2, 2, 4],
      5: [2, 3, 4],
    };

    const values = imprintMap[imprintValue] || [2, 2, 1];

    return values.map((value, index) => ({
      id: index,
      value: value,
    }));
  }

  getCurrentImprintValue(): number {
    switch (this.selectedWeaponType) {
      case 'Normal':
        return this.selectedTricksterWeapon
          ? this.selectedTricksterWeapon.imprintsNormal
          : 0;
      case 'Uncanny':
        return this.selectedTricksterWeapon
          ? this.selectedTricksterWeapon.imprintsUncanny
          : 0;
      case 'Lost':
        return this.selectedTricksterWeapon
          ? this.selectedTricksterWeapon.imprintsLost
          : 0;
      default:
        return 0;
    }
  }

  loadTricksterWeapons(): void {
    this.http
      .get<TricksterWeapon[]>(`${environment.apiUrl}/api/TricksterWeapon`)
      .subscribe({
        next: (data) => {
          this.tricksterWeapons = data;
          this.showTricksterWeaponPopup = true;
        },
        error: (err) => console.error('Error loading trickster weapons:', err),
      });
  }

  selectTricksterWeapon(tricksterWeapon: TricksterWeapon): void {
    this.selectedTricksterWeapon = tricksterWeapon;
    this.showTricksterWeaponPopup = false;
    this.calculateAttackRating();
    this.calculateDamage();
  }

  meetsRequirement(requirement: number, stat: number): boolean {
    return stat >= requirement;
  }

  onWeaponTypeChange(event: any): void {
    this.selectedWeaponType = event.target.value;
  }

  attackRating: string = '0';
  damage: string = '0';

  calculateAttackRating(): void {
    if (!this.selectedTricksterWeapon) return;

    const url =
      `${environment.apiUrl}/api/TricksterWeapon/attack-rating/${this.selectedTricksterWeapon.id}?` +
      `strength=${this.stats.strength}&skill=${this.stats.skill}&` +
      `bloodtinge=${this.stats.bloodtinge}&arcane=${this.stats.arcane}&` +
      `weaponUpgradeLevel=${this.stats.upgradeLevel}`;

    this.http.get<any>(url).subscribe({
      next: (response) => {
        this.attackRating =
          response.physicalAttackRating +
          response.bloodAttackRating +
          response.arcaneAttackRating +
          response.fireAttackRating +
          response.boltAttackRating;
      },
      error: (err) => {
        this.attackRating = '0';
        console.log(err.error);
      },
    });
  }

  openDamagePopup(weapon: TricksterWeapon) {
    if (!weapon.attacks || weapon.attacks.length === 0) {
      console.warn('No attacks available for this weapon');
      return;
    }

    this.selectedWeaponAttacks = weapon.attacks;
    this.showDamagePopup = true;
  }

  closeDamagePopup() {
    this.showDamagePopup = false;
  }

  getAttacksByMode(mode: number): WeaponAttack[] {
    if (!this.selectedWeaponAttacks) return [];
    return this.selectedWeaponAttacks.filter(
      (attack) => attack.attackMode === mode
    );
  }

  attackTypeIcons = [
    null, // 0 - None
    'Physical', // 1
    'Blunt', // 2
    'Thrust', // 3
    'Arcane', // 4
    'Blood', // 5
    'Fire', // 6
    'Bolt', // 7
  ];

  getAttackTypeIcon(type: number): string | null {
    return type > 0 && type < this.attackTypeIcons.length
      ? this.attackTypeIcons[type]
      : null;
  }

  damageData: any[] = [];

  calculateDamage(): void {
    if (!this.selectedTricksterWeapon || !this.selectedBoss) return;

    const url =
      `${environment.apiUrl}/api/Damage/TricksterWeapon/${this.selectedTricksterWeapon.id}/Boss/${this.selectedBoss.id}?` +
      `strength=${this.stats.strength}&skill=${this.stats.skill}&` +
      `bloodtinge=${this.stats.bloodtinge}&arcane=${this.stats.arcane}&` +
      `weaponUpgradeLevel=${this.stats.upgradeLevel}`;

    this.http.get<any[]>(url).subscribe({
      next: (response) => {
        this.damageData = response;
      },
      error: (err) => {
        console.error('Error calculating damage:', err);
        this.damageData = [];
      },
    });
  }

  getDamageForAttack(attackName: string, attackMode: number): string {
    if (!this.damageData) return '0';

    const damageItem = this.damageData.find(
      (item) => item.name === attackName && item.attackMode === attackMode
    );

    if (!damageItem) return '0';

    if (damageItem.extraDamage > 0) {
      return `${damageItem.damage} + ${damageItem.extraDamage} × ${damageItem.extraDamageCount}`;
    }
    return damageItem.damage.toString();
  }
}
