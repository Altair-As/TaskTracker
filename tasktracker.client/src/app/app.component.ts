import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface Process {
  id: number;
  title: string;
}

interface Task {
  id: number;
  text: string;
  description: string;
  priority: number;
  process: Process;
  status: number;
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
