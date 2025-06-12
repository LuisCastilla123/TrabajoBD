import { Component } from '@angular/core';
import {initFlowbite} from 'flowbite';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'CVMakerApp';

  ngOnInit(): void {
    initFlowbite()
  }

}
