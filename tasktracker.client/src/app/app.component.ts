import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Process {
  id: number;
  name: string;
}

interface Task {
  id: number;
  name: string;
  description: string;
  status: number;
  priority: number;
  process: Process;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public tasks: Task[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getTasks();
  }

  getTasks() {
    this.http.get<Task[]>('https://localhost:7082/Tasks').subscribe(
      (result) => {
        this.tasks = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'realtimetasktracker.client';
}
