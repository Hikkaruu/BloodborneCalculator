import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { Boss } from '../../models/boss.model';
import { BossService } from '../../services/boss.service';

@Component({
  selector: 'app-boss-popup',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './boss-popup.component.html',
  styleUrls: ['./boss-popup.component.css'],
})
export class BossPopupComponent {
  selectedBoss: Boss | null = null;
  showBossPopup = false;
  bosses: Boss[] = [];

  constructor(private http: HttpClient, private bossService: BossService) {}

  loadBosses(): void {
    this.http.get<Boss[]>(`${environment.apiUrl}/api/Boss`).subscribe({
      next: (data) => {
        this.bosses = data;
        this.showBossPopup = true;
      },
      error: (err) => console.error('Error loading bosses:', err),
    });
  }

  selectBoss(boss: Boss): void {
    this.selectedBoss = boss;
    this.bossService.setSelectedBoss(boss);
    this.showBossPopup = false;
  }
}
