import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

interface Boss {
  id: number;
  name: string;
  health: number;
  bloodEchoes: number;
  physicalDefense: number;
  bluntDefense: number;
  thrustDefense: number;
  bloodtingeDefense: number;
  arcaneDefense: number;
  fireDefense: number;
  boltDefense: number;
  slowPoisonResistance: number;
  rapidPoisonResistance: number;
  imageUrl: string;
  isRequired: boolean;
  isBeast: boolean;
  isKin: boolean;
}

@Component({
  selector: 'app-boss',
  imports: [CommonModule],
  templateUrl: './boss.component.html',
  styleUrls: ['./boss.component.css'],
})
export class BossComponent implements OnInit {
  bosses: Boss[] = [];
  selectedBoss: Boss | null = null;

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.http.get<Boss[]>(`${environment.apiUrl}/api/Boss`).subscribe({
      next: (data) => {
        this.bosses = data;
        if (this.bosses.length > 0) {
          this.selectedBoss = this.bosses[0];
        }
      },
      error: (err) => console.error('Error loading bosses:', err),
    });
  }

  boolToYesNo(val: boolean): string {
    if (val) return 'Yes';
    else return 'No';
  }

  onBossSelected(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const bossId = Number(selectElement.value);
    this.selectedBoss = this.bosses.find((boss) => boss.id === bossId) || null;
  }
}
