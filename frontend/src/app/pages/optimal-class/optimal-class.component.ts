import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

interface OriginResult {
  name: string;
  level: number;
}

@Component({
  selector: 'app-optimal-class',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './optimal-class.component.html',
  styleUrls: ['./optimal-class.component.css'],
})
export class OptimalClassComponent implements OnInit {
  origins: OriginResult[] = [];
  isLoading = false;
  error: string | null = null;

  stats = {
    vitality: 10,
    endurance: 9,
    strength: 10,
    skill: 9,
    bloodtinge: 7,
    arcane: 9,
  };

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.loadOptimalOrigins();
  }

  loadOptimalOrigins() {
    this.isLoading = true;
    this.error = null;

    const params = {
      desiredVitality: this.stats.vitality.toString(),
      desiredEndurance: this.stats.endurance.toString(),
      desiredStrength: this.stats.strength.toString(),
      desiredSkill: this.stats.skill.toString(),
      desiredBloodtinge: this.stats.bloodtinge.toString(),
      desiredArcane: this.stats.arcane.toString(),
    };

    this.http
      .get<OriginResult[]>(`${environment.apiUrl}/api/Origin/optimal_origins`, {
        params,
      })
      .subscribe({
        next: (data) => {
          this.origins = data;
          this.isLoading = false;
        },
        error: (err) => {
          this.error = 'Error loading optimal origins';
          this.isLoading = false;
          console.error(err);
        },
      });
  }

  increaseStat(statName: string) {
    if (this.stats[statName as keyof typeof this.stats] < 99) {
      this.stats[statName as keyof typeof this.stats]++;
      this.loadOptimalOrigins();
    }
  }

  decreaseStat(statName: string) {
    if (this.stats[statName as keyof typeof this.stats] > 1) {
      this.stats[statName as keyof typeof this.stats]--;
      this.loadOptimalOrigins();
    }
  }

  validateStat(statName: string, event: any) {
    let value = parseInt(event.target.value, 10);

    if (isNaN(value)) {
      value = 1;
    } else if (value < 1) {
      value = 1;
    } else if (value > 99) {
      value = 99;
    }

    this.stats[statName as keyof typeof this.stats] = value;
    event.target.value = value;
    this.loadOptimalOrigins();
  }
}
