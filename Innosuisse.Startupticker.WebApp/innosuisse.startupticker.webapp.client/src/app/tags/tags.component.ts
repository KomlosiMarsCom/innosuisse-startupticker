import { Component, Input } from '@angular/core';
import { ProcessedDataService } from '../../../typescript-client';

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrl: './tags.component.css'
})
export class TagsComponent {
  @Input() id!: string;
  tags: string[];

  constructor(private readonly _processedDataService: ProcessedDataService) {

  }

  ngOnInit() {
    this._processedDataService.tagsGet(this.id).subscribe(tags => {
      this.tags = tags;
    })

  }

  getTagStyle(tag: string): { [key: string]: string } {
    const colors = this.tagColorMap(tag);
    return {
      backgroundColor: colors.bg,
      color: colors.text
    };
  }

  tagColorMap(tag: string): { bg: string; text: string } {
    const hash = [...tag].reduce((acc, char) => acc + char.charCodeAt(0), 0);
    const colorList = [
      { bg: '#e0f7fa', text: '#00796b' },
      { bg: '#f3e5f5', text: '#6a1b9a' },
      { bg: '#ffe0b2', text: '#e65100' },
      { bg: '#dcedc8', text: '#33691e' },
      { bg: '#ffccbc', text: '#bf360c' },
      { bg: '#d1c4e9', text: '#4527a0' },
      { bg: '#c8e6c9', text: '#2e7d32' },
    ];
    return colorList[hash % colorList.length];
  }
}
