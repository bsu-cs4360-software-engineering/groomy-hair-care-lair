# Design Document

## 1. Color Scheme
Below is a list of the colors used in the design, along with the context for their usage.

- **Primary Background Color**:  
  - `#215C82` (RGB: 33, 92, 130)  
  - **Context**: This is the background color for the sidebar on the left side of the application.
  
- **Label Color**:  
  - `#215C82` (RGB: 33, 92, 130)  
  - **Context**: All labels within the application use this color, providing consistency with the sidebar’s design.

- **Button Background Color**:  
  - `#215C82` (RGB: 33, 92, 130)  
  - **Context**: Buttons use this color for the background, ensuring they stand out within the interface.

- **Button Text Color**:  
  - `#FFFFFF` (RGB: 255, 255, 255)  
  - **Context**: The text on buttons is white to contrast well with the dark blue background.

- **Sidebar Highlighted Element Color**:  
  - `#1D81AF` (RGB: 29, 129, 175)  
  - **Context**: When a sidebar element is highlighted (active or hovered), this color is applied to draw attention to the selected item.

- **DataGridView Background Color**:  
  - `#333333` (RGB: 51, 51, 51) (ControlDark)  
  - **Context**: The background color for the DataGridView control. It provides a neutral backdrop for the content.
  
- **DataGridView Row Background Color**:  
  - `#FFFFFF` (RGB: 255, 255, 255)  
  - **Context**: Each row in the DataGridView has a white background for readability.

- **DataGridView Text Color**:  
  - `#000000` (RGB: 0, 0, 0)  
  - **Context**: The text in the DataGridView rows is black to ensure high contrast with the white background.

## 2. Form Elements and Their Design

The form elements are detailed below, highlighting their design specifications:

- **Sidebar**:  
  - **Size**: 221px width, 566px height  
  - **Background Color**: `#215C82` (RGB: 33, 92, 130)  
  - **Text Color**: `#215C82` (RGB: 33, 92, 130)  
  - **Behavior**: The sidebar is positioned on the left side and holds various navigational elements. Items within the sidebar have a dark background, and highlighted elements change to `#1D81AF` (RGB: 29, 129, 175).

- **Labels**:  
  - **Font Size**: 24pt  
  - **Font Color**: `#215C82` (RGB: 33, 92, 130)  
  - **Context**: All labels use this color for a consistent design across the forms, and the size ensures they stand out as headers.

- **Buttons**:  
  - **Background Color**: `#215C82` (RGB: 33, 92, 130)  
  - **Text Color**: `#FFFFFF` (RGB: 255, 255, 255)  
  - **Border**: None (Solid flat design)  
  - **Corner Radius**: 8px  
  - **Context**: Buttons are designed with the primary color and white text, and rounded corners are applied for a modern, friendly appearance.

- **Input Fields**:  
  - **Border**: 1px solid `#215C82` (RGB: 33, 92, 130)  
  - **Corner Radius**: 8px  
  - **Text Color**: `#000000` (RGB: 0, 0, 0)  
  - **Background Color**: White  
  - **Context**: Input fields have a thin blue border to match the sidebar and button color, with rounded corners to soften the design.

- **DataGridView**:  
  - **Background Color**: `#333333` (RGB: 51, 51, 51)  
  - **Row Background Color**: `#FFFFFF` (RGB: 255, 255, 255)  
  - **Text Color**: `#000000` (RGB: 0, 0, 0)  
  - **Context**: The DataGridView uses a dark background with white rows and black text for easy data reading. This provides high contrast while maintaining a clean, professional look.

## 3. Layout
The layout structure for the forms is as follows:

- **Panel Layout**:  
  The layout utilizes a panel structure to group elements into logical sections. This helps create a neat and organized interface.

- **Heading**:  
  - **Font Size**: 24pt  
  - **Font Color**: `#215C82` (RGB: 33, 92, 130)  
  - **Context**: The headings use a large, bold font size to clearly distinguish them from other text. The color matches the theme of the sidebar for consistency.

- **Content Below Heading**:  
  - **Context**: Below each heading, content elements (such as input fields, buttons, and text) are displayed in a clean, structured manner. Each content section has appropriate padding and margins for readability.
